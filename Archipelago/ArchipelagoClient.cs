using System.Collections.Concurrent;
using Archipelago.MultiClient.Net;
using Archipelago.MultiClient.Net.BounceFeatures.DeathLink;
using Archipelago.MultiClient.Net.Models;
using Archipelago.MultiClient.Net.Enums;
using Archipelago.MultiClient.Net.Helpers;
using Archipelago.MultiClient.Net.Packets;
using System.Collections.Generic;
using CarQuestAP.Helpers;
using HarmonyLib;
using UnityEngine;
using System;

namespace CarQuestAP.Archipelago {
    public class ArchipelagoClient : MonoBehaviour {
        public ArchipelagoClient(IntPtr ptr) : base(ptr) {}

        public static int[] AP_VERSION = {0, 6, 7};
        public const string GAME_NAME = "Secret Game";

        public bool isAuthenticated = false;
        public int slotID;
        public ArchipelagoSession session;
        public bool deathLinkStatus = false;
        public DeathLinkService deathLinkService;
        public Dictionary<string, int> itemsRecieved = new Dictionary<string, int>();
        public ConcurrentQueue<string> secretQueue  =new ConcurrentQueue<string>();
        
        public bool Connect(string address, string slot, string password) {
            if(isAuthenticated) {
                return true;
            }

            session = ArchipelagoSessionFactory.CreateSession(address);

            LoginResult loginResult = session.TryConnectAndLogin(
                GAME_NAME,
                slot,
                ItemsHandlingFlags.AllItems,
                new Version(AP_VERSION[0], AP_VERSION[1], AP_VERSION[2]),
                null,
                "",
                password
            );

            if(loginResult is LoginSuccessful loginSuccess) {
                isAuthenticated = true;
                session.Items.ItemReceived += Session_ItemReceived;

                return true;
            }

            return false;
        }

        private void Session_ItemReceived(ReceivedItemsHelper helper) {
            ItemInfo item = helper.DequeueItem();
            CarQuestAP._log.LogInfo($"[ItemRecieved] Received {item.ItemName} ({item.ItemId})");
            
            if(itemsRecieved.ContainsKey(item.ItemName)) {
                itemsRecieved[item.ItemName]++;
            }
            else {
                itemsRecieved[item.ItemName] = 1;
            }

            if(item.ItemId < 500) {
                string secret = SecretHandler.unlockSecret(item.ItemName, itemsRecieved[item.ItemName]);
                if(secret != null) {
                    secretQueue.Enqueue(secret);
                }
            }

            if(item.ItemId == 10001) FindObjectOfType<GameControl>().AddCoin(1);
            if(item.ItemId == 10002) FindObjectOfType<GameControl>().AddCoin(25);
            if(item.ItemId == 10003) FindObjectOfType<GameControl>().AddCoin(50);
        }

        public void sendLocation(string locName) {
            long locID = session.Locations.GetLocationIdFromName(GAME_NAME, locName);

            if(locID != -1) {
                CarQuestAP._log.LogInfo($"Sending {locName} [{locID}]");
                session.Locations.CompleteLocationChecksAsync(locID);
            }
            else {
                CarQuestAP._log.LogError($"{locName} location not found!");
            }
        }

        public void goalGame() {
            var statusUpdatePacket = new StatusUpdatePacket {
                Status = ArchipelagoClientState.ClientGoal
            };
            session.Socket.SendPacket(statusUpdatePacket);
        }

        private void Update() {
            if(!secretQueue.IsEmpty) {
                secretQueue.TryDequeue(out var result);
                CarQuestAP._log.LogInfo($"[APClient Update] Unlocking {result}");
                eSecret.SetValue("ap_" + result, 1, true);
            }
        }
    }
}
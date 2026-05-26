using System.Collections.Concurrent;
using Archipelago.MultiClient.Net;
using Archipelago.MultiClient.Net.BounceFeatures.DeathLink;
using Archipelago.MultiClient.Net.Models;
using Archipelago.MultiClient.Net.Enums;
using Archipelago.MultiClient.Net.Helpers;
using System.Collections.Generic;
using CarQuestAP.Helpers;
using HarmonyLib;

namespace CarQuestAP.Archipelago {
    public static class ArchipelagoClient {
        public static int[] AP_VERSION = {0, 6, 1};
        public const string GAME_NAME = "Car Quest Deluxe";

        public static ConcurrentQueue<ItemInfo> _itemQueue = new();
        public static bool isAuthenticated = false;
        public static int slotID;
        public static ArchipelagoSession session;
        public static bool deathLinkStatus = false;
        public static DeathLinkService deathLinkService;
        public static Dictionary<string, int> itemsRecieved = new Dictionary<string, int>();
        
        public static bool Connect(string address, string slot, string password) {
            if(isAuthenticated) {
                return true;
            }

            session = ArchipelagoSessionFactory.CreateSession(address);

            LoginResult loginResult = session.TryConnectAndLogin(
                GAME_NAME,
                slot,
                ItemsHandlingFlags.AllItems,
                new System.Version(AP_VERSION[0], AP_VERSION[1], AP_VERSION[2]),
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

        private static void Session_ItemReceived(ReceivedItemsHelper helper) {
            ItemInfo item = helper.DequeueItem();
            
            if(itemsRecieved.ContainsKey(item.ItemName)) {
                itemsRecieved[item.ItemName]++;
            }
            else {
                itemsRecieved[item.ItemName] = 1;
            }

            SecretHandler.unlockSecret(item.ItemName, itemsRecieved[item.ItemName]);
        }

        public static void sendLocation(string locName) {
            long locID = session.Locations.GetLocationIdFromName(GAME_NAME, locName);

            if(locID != -1) {
                CarQuestAP._log.LogInfo($"Sending {locName} [{locID}]");
                session.Locations.CompleteLocationChecksAsync(locID);
            }
            else {
                CarQuestAP._log.LogError($"{locName} location not found!");
            }
        }
    }
}
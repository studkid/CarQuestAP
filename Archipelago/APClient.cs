using System.Collections.Concurrent;
using Archipelago.MultiClient.Net;
using Archipelago.MultiClient.Net.BounceFeatures.DeathLink;
using Archipelago.MultiClient.Net.Models;
using Archipelago.MultiClient.Net.Enums;
using Archipelago.MultiClient.Net.Helpers;

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
        
        public static bool Connect(string address, string slot, string password) {
            if(isAuthenticated) {
                return true; // Probably won't ever run tbh
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
            
        }
    }
}
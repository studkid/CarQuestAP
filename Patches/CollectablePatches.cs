using HarmonyLib;
using CarQuestAP.Helpers;
using CarQuestAP.Archipelago;

namespace CarQuestAP.Patches {
    [HarmonyPatch(typeof(SecretCollect), "OnTriggerEnter")]
    public static class SecretCollectSend {
        [HarmonyPostfix]
        public static void PostFix(ref SecretCollect __instance) {
            if(__instance.state != "collected") {
                return;
            }

            if(SecretHandler.getLocationName(__instance.secretID) != "") {
                CarQuestAP._log.LogInfo($"Secret ID: {__instance.secretID} Location Name: {SecretHandler.getLocationName(__instance.secretID)}");
                CarQuestAP.apClient.sendLocation(SecretHandler.getLocationName(__instance.secretID));
                CarQuestAP.saves[CarQuestAP.saveSlot].AddNewLocation(__instance.secretID);
            }
            else {
                CarQuestAP._log.LogError($"Secret ID: {__instance.secretID} Not Mapped!");
            }
            
            // CarQuestAP.saves[0].AddNewSecret(__instance.secretID);
        }

        // [HarmonyPrefix]
        // public static void PreFix(ref SecretCollect __instance) {
        //     if(__instance.state == "collected") {
        //         return;
        //     }
        // }
    }

    [HarmonyPatch(typeof(eSecret), "SetValue")]
    public static class eSecretChangeList {
        [HarmonyPrefix]
        public static void PreFix(ref string key, ref int value, ref bool addChangeList) {
            CarQuestAP._log.LogInfo($"[SetValue] {key}");
            if(key.Contains("ap_")) {
                key = key.Substring(3);
                CarQuestAP._log.LogInfo($"[SetValue] {key}");
            }
            else {
                value = 0;
                addChangeList = false;
                return;
            }
        }
    }

    [HarmonyPatch(typeof(SecretCollect), "SecretChangedDelay")]
    public static class RespawnSecret {
        [HarmonyPostfix]
        public static void PostFix(ref SecretCollect __instance) {
            if(!CarQuestAP.saves[CarQuestAP.saveSlot].LocationChecked(__instance.secretID)) {
                __instance.secretObject.SetActive(true);
            }
            else {
                __instance.secretObject.SetActive(false);
            }
        }
    }

    [HarmonyPatch(typeof(Token), "OnTriggerEnter")]
    public static class PrintToken {
        [HarmonyPostfix]
        public static void PostFix(ref Token __instance) {
            CarQuestAP._log.LogInfo($"Token ID: {__instance.tokenID}");
        }
    }

    [HarmonyPatch(typeof(Coin), "PlayerCollect")]
    public static class PrintCoin {
        [HarmonyPostfix]
        public static void PostFix(ref Coin __instance) {
            // CarQuestAP._log.LogInfo("Battery " + __instance.posOrig.ToString());
        }
    }

    [HarmonyPatch(typeof(GameControl), "AddCoin")]
    public static class SaveCoin {
        [HarmonyPostfix]
        public static void PostFix(ref int howMuch) {
            CarQuestAP.saves[0].AddBattery(howMuch);
        }
    }

    [HarmonyPatch(typeof(Portal), "OnTriggerEnter")]
    public static class GoalChecker {
        [HarmonyPostfix]
        public static void PostFix(ref Portal __instance) {
            if(__instance.name == "PortalLeave" || __instance.name == "PortalStay") {
                CarQuestAP.apClient.goalGame();
            }
        }
    }
}
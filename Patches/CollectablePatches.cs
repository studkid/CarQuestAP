using HarmonyLib;
using CarQuestAP.Helpers;

namespace CarQuestAP.Patches {
    [HarmonyPatch(typeof(SecretCollect), "OnTriggerEnter")]
    public static class PrintSecret {
        [HarmonyPostfix]
        public static void PostFix(ref SecretCollect __instance) {
            CarQuestAP._log.LogInfo($"Secret ID: {__instance.secretID}");
            CarQuestAP.saves[0].AddNewSecret(__instance.secretID);
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
}
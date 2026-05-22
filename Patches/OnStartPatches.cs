using System;
using CarQuestAP.Archipelago;
using CarQuestAP.Helpers;
using HarmonyLib;
using UnityEngine;
using UnityEngine.UI;

namespace CarQuestAP.Patches {
    [HarmonyPatch(typeof(Menu), "DoAction")]
    public static class SaveOverride {
        [HarmonyPrefix]
        public static void PreFix(ref string action, ref Menu __instance) {
            float realtimeSinceStartup = Time.realtimeSinceStartup;
            if(__instance.delayTime >= realtimeSinceStartup) {
                return;
            }

            if(action == "Start" && !ArchipelagoClient.isAuthenticated) {
                __instance.MenuShow("SaveProfiles");
                return;
            }

            if(action.Contains("Slot")) {
                char[] actionChar = action.ToCharArray();
                int slotNum = int.Parse(actionChar[^1].ToString()) + 1;
                ePlayerPrefs.SetSlot(slotNum);
                CarQuestAP._log.LogInfo($"Trying connection on Slot {slotNum} {int.Parse(actionChar[^1].ToString())}");
                SaveInfo info = CarQuestAP.saves[slotNum - 1].GetSaveInfo();
                CarQuestAP._log.LogInfo($"Trying connection with {info.address}, {info.slotName}");
                ArchipelagoClient.Connect(info.address, info.slotName, info.password);
                if(ArchipelagoClient.isAuthenticated) {
                    __instance.DoAction("Start");
                }
                return;
            }

            // if(action == "Start") {
            //     eSecret.DeleteAll();
            //     CarQuestAP.saveHandler.LoadAPSave();
            // }

            if(action == "SaveProfiles") {
                __instance.MenuShow("ItemMenu");
                return;
            }
        }
    }

    [HarmonyPatch(typeof(Menu), "Awake")]
    public static class ModifyMenuButtons {
        [HarmonyPostfix]
        public static void PostFix(ref Menu __instance) {
            // Modify Save Profile Menu
            Transform saveMenu = __instance.menus[9].GetChild(1);
            for(int i = 0; i < saveMenu.childCount; i++) {
                if(i + 1 > CarQuestAP.saves.Count) continue;

                Transform buttonTrans = saveMenu.GetChild(i);
                Text text = buttonTrans.GetChild(1).GetComponent<Text>();
                Button button = buttonTrans.GetComponent<Button>();

                if(text != null) {
                    CarQuestAP._log.LogInfo(CarQuestAP.saves[i].GetSaveInfo());
                    SaveInfo info = CarQuestAP.saves[i].GetSaveInfo();
                    text.text = $"Save Slot {info.saveSlot}: {info.slotName}\n{info.address}";
                }
            }
            // ConnectionUI.CreateConUI(__instance.menus[9]);

            // Add Item Menu
            APItemMenu.createItemMenu(__instance);

            // Modify Pause Menu
            APItemMenu.updatePauseMenu(__instance);
        }
    }
}
using System;
using System.Collections.Generic;
using CarQuestAP.Archipelago;
using HarmonyLib;
using UnityEngine;
using UnityEngine.Events;
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

            if(action == "Start") {
                __instance.MenuShow("SaveProfiles");
                return;
            }

            if(action.Contains("Slot")) {
                int slotNum = Convert.ToInt32(action[^1]) + 1;
                ePlayerPrefs.SetSlot(slotNum);
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
                    text.text = CarQuestAP.saves[i].GetSaveInfo();
                }
            }

            // Add Item Menu
            APItemMenu.CreateItemMenu(__instance);

            // Modify Pause Menu
            APItemMenu.UpdatePauseMenu(__instance);
        }
    }
}
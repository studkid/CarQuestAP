using System;
using System.Collections.Generic;
using HarmonyLib;
using UnityEngine;
using UnityEngine.UI;

namespace CarQuestAP.Patches {
    [HarmonyPatch(typeof(Menu), "DoAction")]
    public static class SaveOverride {
        [HarmonyPrefix]
        public static void PreFix(ref string action, ref Menu __instance) {
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
            GameObject menu = __instance.gameObject;
            GameObject itemMenu = GameObject.Instantiate(__instance.menus[11].gameObject);
            itemMenu.name = "ItemMenu";
            itemMenu.SetActive(true);

            itemMenu.transform.GetChild(0).gameObject.name = "Top";
            GameObject dropDown = itemMenu.transform.GetChild(0).GetChild(0).gameObject;
            CarQuestAP._log.LogInfo(dropDown.GetComponent<Dropdown>());
            dropDown.GetComponent<Dropdown>().ClearOptions();
            Il2CppSystem.Collections.Generic.List<string> options = new Il2CppSystem.Collections.Generic.List<string>();
            options.Add("Hub");
            dropDown.GetComponent<Dropdown>().AddOptions(options);

            __instance.menus.Add(itemMenu.transform);
            itemMenu.transform.SetParent(menu.GetComponent<Transform>());
        }
    }
}
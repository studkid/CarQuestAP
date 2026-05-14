using System;
using System.Collections.Generic;
using HarmonyLib;
using UnityEngine;
using UnityEngine.UI;

namespace CarQuestAP.Archipelago {
    public static class APItemMenu {
        public static void CreateItemMenu(Menu __instance) {
            GameObject menu = __instance.gameObject;
            GameObject itemMenu = UnityEngine.Object.Instantiate(__instance.menus[11].gameObject);
            itemMenu.name = "ItemMenu";

            itemMenu.transform.GetChild(0).gameObject.name = "Top";
            GameObject dropDown = itemMenu.transform.GetChild(0).GetChild(0).gameObject;
            dropDown.GetComponent<Dropdown>().ClearOptions();
            Il2CppSystem.Collections.Generic.List<string> options = new Il2CppSystem.Collections.Generic.List<string>();
            options.Add("Hub");
            dropDown.GetComponent<Dropdown>().AddOptions(options);

            UnityEngine.Object.Destroy(dropDown.GetComponent<SecretDropdown>());

            __instance.menus.Add(itemMenu.transform);
            itemMenu.transform.SetParent(menu.GetComponent<Transform>());
        }

        public static void UpdatePauseMenu(Menu __instance) {
            Transform pauseMenuTrans = __instance.menus[3].GetChild(1).GetChild(7);
            pauseMenuTrans.gameObject.SetActive(true);
            CarQuestAP._log.LogInfo(pauseMenuTrans.GetChild(0).GetComponent<Text>().text);
            pauseMenuTrans.GetChild(0).GetComponent<Text>().text = "Recieved Items";
            CarQuestAP._log.LogInfo(pauseMenuTrans.GetChild(0).GetComponent<Text>().text);
            UnityEngine.Object.Destroy(pauseMenuTrans.GetChild(0).GetComponent<TranslateUI>());
        }
    }
}
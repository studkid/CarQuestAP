using UnityEngine;
using UnityEngine.UI;
using CarQuestAP.Helpers;
using UnityEngine.Events;
using System.Collections.Generic;

namespace CarQuestAP.Archipelago {
    public static class APItemMenu {
        private static Dictionary<string, GameObject> buttons = new Dictionary<string, GameObject>();
        private static Sprite normalButton;
        private static Sprite cheatButton;

        public static void createItemMenu(Menu __instance) {
            // Create Menu object and Dropdown
            GameObject menu = __instance.gameObject;
            GameObject itemMenu = Object.Instantiate(__instance.menus[11].gameObject);
            itemMenu.name = "ItemMenu";

            // itemMenu.transform.GetChild(0).gameObject.name = "Top";
            // GameObject dropDown = itemMenu.transform.GetChild(0).GetChild(0).gameObject;
            // dropDown.GetComponent<Dropdown>().ClearOptions();
            // Il2CppSystem.Collections.Generic.List<string> options = new Il2CppSystem.Collections.Generic.List<string>();
            // options.Add("Hub");
            // dropDown.GetComponent<Dropdown>().AddOptions(options);

            // Object.Destroy(dropDown.GetComponent<SecretDropdown>());

            // Create Buttons
            GameObject itemTrans = Object.Instantiate(__instance.menus[10].GetChild(0).gameObject);
            itemTrans.name = "Middle";
            GameObject backTrans = Object.Instantiate(__instance.menus[10].GetChild(1).gameObject);
            backTrans.name = "Bottom";

            GridLayoutGroup itemLayout = itemTrans.GetComponent<GridLayoutGroup>();
            itemLayout.constraintCount = 3;
            itemTrans.GetComponent<RectTransform>().sizeDelta = new Vector2(1000, 694);

            GameObject btnTransTemplate = Object.Instantiate(itemTrans.transform.GetChild(0).gameObject);
            Object.DestroyImmediate(btnTransTemplate.GetComponent<Button>());
            CarQuestAP._log.LogInfo(btnTransTemplate.GetComponent<Button>());
            for(int i = itemTrans.transform.childCount - 1; i >=0 ; i--) {
                Object.Destroy(itemTrans.transform.GetChild(i).gameObject);
            }

            ContentSizeFitter sizeFitter = itemTrans.AddComponent<ContentSizeFitter>();
            sizeFitter.verticalFit = ContentSizeFitter.FitMode.PreferredSize;
            ScrollRect itemScroll = itemMenu.AddComponent<ScrollRect>();
            itemScroll.content = itemTrans.GetComponent<RectTransform>();
            itemScroll.scrollSensitivity = 20;
            itemScroll.horizontal = false;

            foreach(string secret in SecretHandler.getHubSecrets().Keys) {
                GameObject newTransBtn = Object.Instantiate(btnTransTemplate);
                CarQuestAP._log.LogInfo(newTransBtn.GetComponent<Button>());
                newTransBtn.name = secret;
                newTransBtn.transform.GetChild(0).GetComponent<Text>().text = secret;
                Object.Destroy(newTransBtn.transform.GetChild(0).GetComponent<DisplayDataUI>());
                Button newBtn = newTransBtn.AddComponent<Button>();
                newBtn.onClick.AddListener((UnityAction)delegate{toggleSecret(secret, newTransBtn.GetComponent<Image>());});
                newTransBtn.SetActive(false);
                buttons[secret] = newTransBtn;

                newTransBtn.transform.SetParent(itemTrans.transform);
            }
            
            backTrans.transform.SetParent(itemMenu.transform);
            itemTrans.transform.SetParent(itemMenu.transform);

            // Add menu to Menus list
            __instance.menus.Add(itemMenu.transform);
            itemMenu.transform.SetParent(menu.transform);
        }

        public static void updatePauseMenu(Menu __instance) {
            Transform saveProfileTrans = __instance.menus[3].GetChild(1).GetChild(7);
            saveProfileTrans.gameObject.SetActive(true);
            saveProfileTrans.GetChild(0).GetComponent<Text>().text = "Recieved Items";
            Object.Destroy(saveProfileTrans.GetChild(0).GetComponent<TranslateUI>());
            normalButton = saveProfileTrans.GetComponent<Image>().activeSprite;

            Transform toggleHintsTrans = __instance.menus[3].GetChild(1).GetChild(12);
            toggleHintsTrans.gameObject.SetActive(true);
            toggleHintsTrans.GetChild(0).GetComponent<Text>().text = "Warp to Start";
            Object.Destroy(toggleHintsTrans.GetChild(0).GetComponent<DisplayDataUI>());
            cheatButton = toggleHintsTrans.GetComponent<Image>().activeSprite;
        }

        public static void updateItemMenu() {
            foreach(string key in CarQuestAP.apClient.itemsRecieved.Keys) {
                if(buttons.ContainsKey(key)) {
                    buttons[key].SetActive(true);
                }
            }
        }

        public static void toggleSecret(string locName, Image image) {
            int value = eSecret.GetValue(SecretHandler.locToSecretID(locName)[0]);
            if(value == 0) {
                eSecret.SetValue("ap_" + SecretHandler.locToSecretID(locName)[0], 1, true);
                image.sprite = cheatButton;
            }
            else {
                eSecret.SetValue("ap_" + SecretHandler.locToSecretID(locName)[0], 0, true);
                image.sprite = normalButton;
            }
        }
    }
}
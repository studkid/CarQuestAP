using UnityEngine;
using CarQuestAP.Archipelago;
using CarQuestAP.Helpers;
using UnityEngine.UI;

namespace CarQuestAP.UI {
    public static class ConnectionUI {
        public static void CreateConUI(Transform menu) {
            GameObject connectObj = new GameObject {
                name = "AP Connect"
            };
            CarQuestAP._log.LogInfo(menu.name);

            // Yoinked directly from Corn Kidz randomizer, which was yoinked directly from Subnautica randomizer
            // https://github.com/Berserker66/ArchipelagoSubnauticaModSrc/blob/master/mod/Archipelago.cs
            // if (ArchipelagoClient.session != null) {
            //     if (ArchipelagoClient.isAuthenticated) {
            //         Text text = connectObj.AddComponent<Text>();
            //         text.rectTransform.sizeDelta = new Vector2(300,20);
            //         text.rectTransform.position = new Vector2(16, 16);
            //         text.text = "Status: Connected";
            //     }
            //     else {
            //         Text text = connectObj.AddComponent<Text>();
            //         text.rectTransform.sizeDelta = new Vector2(300,20);
            //         text.rectTransform.position = new Vector2(16, 16);
            //         text.text = "Authentication failed";
            //     }
            // }
            // else {
                Text text = connectObj.AddComponent<Text>();
                // text.rectTransform.sizeDelta = new Vector2(300,20);
                // text.rectTransform.position = new Vector2(16, 16);
                text.text = "Status: Not Connected";
            // }

            // if (ArchipelagoClient.session == null || !ArchipelagoClient.isAuthenticated) {
            //     GUI.Label(new Rect(16, 36, 150, 20), "Host: ");
            //     GUI.Label(new Rect(16, 56, 150, 20), "Slot Name: ");
            //     GUI.Label(new Rect(16, 76, 150, 20), "Password: ");

            //     bool submit = Event.current.type == EventType.KeyDown && Event.current.keyCode == KeyCode.Return;
            //     SaveInfo info = new SaveInfo();

            //     info.address = GUI.TextField(new Rect(150 + 16 + 8, 36, 150, 20), info.address);
            //     info.slot = GUI.TextField(new Rect(150 + 16 + 8, 56, 150, 20), info.slotName);
            //     info.password = GUI.TextField(new Rect(150 + 16 + 8, 76, 150, 20), info.password);

            //     if (submit && Event.current.type == EventType.KeyDown) {
            //         // The text fields have not consumed the event, which means they were not focused.
            //         submit = false;
            //     }

            //     if ((GUI.Button(new Rect(16, 96, 100, 20), "Connect") || submit) && info.Valid) {
            //         ArchipelagoClient.Connect();
            //         if(ArchipelagoClient.isAuthenticated) {
            //             // ItemHandler.Setup();
            //         }
            //     }
            // }
            // else if( ArchipelagoClient.session != null) {
            //     if(GUI.Button(new Rect(16, 76, 100, 20), "Disconnect")) {
            //         ArchipelagoClient.Disconnect();
            //     }

            connectObj.transform.SetParent(menu);
        }
    }
}
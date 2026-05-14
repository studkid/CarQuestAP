using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace CarQuestAP.Helpers {
    public class SaveHandler {
        internal string savePath = Path.Combine(Directory.GetCurrentDirectory(), "APSaves");
        internal SaveInfo saveInfo;
        
 
        public SaveHandler(string address, string slotName, string password, int saveSlot) {
            saveInfo = new SaveInfo {
                saveSlot = saveSlot,
                address = address,
                slotName = slotName,
                password = password,
                secrets = new Dictionary<string, int>(),
                tokens = 0,
                batteries = 0,
            };
            
            LoadAPSave();
        }

        private void SaveAPSave() {
            if(!Directory.Exists(savePath)) {
                Directory.CreateDirectory(savePath);
            }

            string fileName = "save" + saveInfo.saveSlot + ".json";
            string jsonString = JsonSerializer.Serialize(saveInfo);
            File.WriteAllText(Path.Combine(savePath, fileName), jsonString);
        }

        public void LoadAPSave() {
            // Returns if save doesn't exist
            string fileName = "save" + saveInfo.saveSlot + ".json";
            if(!File.Exists(Path.Combine(savePath, fileName))) {
                CarQuestAP._log.LogInfo("No save file found, creating new save data");
                return;
            }
            
            string jsonString = File.ReadAllText(Path.Combine(savePath, fileName));
            saveInfo = JsonSerializer.Deserialize<SaveInfo>(jsonString);

            // foreach(string key in saveInfo.secrets.Keys) {
            //     eSecret.AddChangeList(key);
            // }
        }

        public void AddNewSecret(string secret) {
            if(!saveInfo.secrets.ContainsKey(secret)) {
                saveInfo.secrets.Add(secret, 1);
                SaveAPSave();
            }
        }

        public void AddToken(int amount) {
            saveInfo.tokens =+ amount;
            SaveAPSave();
        }

        public void AddBattery(int amount) {
            saveInfo.batteries =+ amount;
            SaveAPSave();
        }

        public string GetSaveInfo() {
            return $"Save Slot {saveInfo.saveSlot}: {saveInfo.slotName}\n{saveInfo.address}";
        }
    }
}
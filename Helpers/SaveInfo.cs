using System.Collections.Generic;

namespace CarQuestAP.Helpers {
    public class SaveInfo {
        public int saveSlot { get; set; }
        public string address { get; set; }
        public string slotName { get; set; }
        public string password { get; set; }
        public Dictionary<string, int> secrets { get; set; }
        public int tokens { get; set; } 
        public int batteries { get; set; }
    }
}
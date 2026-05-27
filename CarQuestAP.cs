using System.Collections.Generic;
using BepInEx;
using BepInEx.Logging;
using BepInEx.Unity.IL2CPP;
using CarQuestAP.Helpers;
using HarmonyLib;

namespace CarQuestAP;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class CarQuestAP : BasePlugin {
    public static ManualLogSource _log;
    public static List<SaveHandler> saves = new List<SaveHandler>();
    public static int saveSlot = 0;

    public override void Load() {
        var harmony = new Harmony("Archipelago");
        
        // Plugin startup logic
        _log = Log;
        _log.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");
        harmony.PatchAll();
        _log.LogInfo("Harmony patches applied!");
        saves.Add(new SaveHandler("localhost", "Player2", "", 1));
    }
}

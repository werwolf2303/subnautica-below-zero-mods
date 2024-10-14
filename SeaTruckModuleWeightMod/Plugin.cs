using HarmonyLib;
using QModManager.API.ModLoading;
using System.Reflection;
using Logger = QModManager.Utility.Logger;
using Nautilus.Handlers;
using Nautilus.Json;
using Nautilus.Options.Attributes;


namespace SeaTruckModuleWeightMod_BZ
{
    [QModCore]
    public static class Plugin
    {
        internal static Config Config { get; } = OptionsPanelHandler.RegisterModOptions<Config>();


        [QModPatch]
        public static void Patch()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var modName = ($"nkrista_{assembly.GetName().Name}");

            Logger.Log(Logger.Level.Info, $"Patching {modName}");

            Harmony harmony = new Harmony(modName);
            harmony.PatchAll(assembly);

            Logger.Log(Logger.Level.Info, "Patched successfully!");
        }
    }

    /// <summary>
    /// Set up mod options in menu
    /// </summary>
    [Menu("Seatruck Module Weight")]
    public class Config : ConfigFile
    {
        [ToggleAttribute("Seatruck modules add weight")]
        public bool ShouldSeatruckModulesAddWeight = false;
    }
}

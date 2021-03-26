using System.Reflection;
using HarmonyLib;
using BepInEx;
using BepInEx.Configuration;

namespace CustomDOF
{
    [BepInPlugin("SSyl.CustomDOF", "CustomDOF", "1.0.0")]
    public class CustomDOF : BaseUnityPlugin
    {
        public static ConfigEntry<bool> modEnabled;
        public static ConfigEntry<float> dofMinDistance;
        public static ConfigEntry<float> dofMaxDistance;
        public static ConfigEntry<int> nexusID;

        private void Awake()
        {
            modEnabled = Config.Bind("General", "Enabled", true, "Settings this to false disables all features of this mod.");
            dofMinDistance = Config.Bind("General", "DepthofFieldMinDistance", 75f, "The minimum distance from the camera that will get blurred.\nHigher value stops the camera from blurring close objects. Lower value makes the camera blur closer.\nGame Default = 50\nMod default = 75");
            dofMaxDistance = Config.Bind("General", "DepthofFieldMaxDistance", 3000f, "How far away objects can be before they get blurred.\nLower values increases blur on distant objects. Higher values make it so only very distant objects get blurred.\nGame default = 3000\nThe game's default value seems to work well.");

            if (!modEnabled.Value)
                return;

                Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly(), "SSyl.CustomDOF");
        }
    }
}

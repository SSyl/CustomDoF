using HarmonyLib;

namespace CustomDOF
{
    [HarmonyPatch(typeof(CameraEffects), "UpdateDOF")]
    class CameraEffects_Patch
    {
        public static void Prefix(ref CameraEffects __instance)
        {
            __instance.m_dofMinDistance = CustomDOF.dofMinDistance.Value;
            __instance.m_dofMinDistanceShip = CustomDOF.dofMaxDistance.Value; // This is the minimum DOF while you're on a ship. By default, it's set to 50 which is the same as when you're not on a ship.
            __instance.m_dofMaxDistance = CustomDOF.dofMaxDistance.Value;
        }
    }
}

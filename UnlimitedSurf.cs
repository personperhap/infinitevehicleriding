using System;
using BepInEx;
using HarmonyLib;

namespace infinitevehicleriding
{
    [BepInPlugin("com.personperhaps.unlimitedsurf", "unlimitedsurf", "1.0")]
    public class UnlimitedSurf : BaseUnityPlugin
    {
        UnlimitedSurf instance = null;
        void Start()
        {
            instance = this;
            Harmony harmony = new Harmony("unlimitedsurf");
            harmony.PatchAll();
        }
        [HarmonyPatch(typeof(FpsActorController), nameof(FpsActorController.CanBeRammedBy))]
        public class CanBeRammedBy
        {
            public static void Postfix(FpsActorController __instance, ref bool __result, Vehicle vehicle)
            {
                __result = __instance.movingPlatformVehicle != vehicle || vehicle.Velocity().sqrMagnitude > 400f;
                __result = false;
            }
        }
    }
}

using CodeExplorer.Core;
using HarmonyLib;
using Verse;

namespace CodeExplorer.Patch
{
  [HarmonyPatch(typeof(DebugWindowsOpener), "DrawButtons")]
  public static class RimWorld_PlaySettings_DoPlaySettingsGlobalControls
  {
    private static void Postfix(WidgetRow ___widgetRow)
    {
      if (!___widgetRow.ButtonIcon(Textures.ToggleIcon, Mod.Name)) { return; }

      Dialog_Main.Open();
    }
  }
}
// using CodeExplorer.Core;
// using HarmonyLib;
// using RimWorld;
// using Verse;
//
// namespace CodeExplorer.Patch
// {
//   [HarmonyPatch(typeof(PlaySettings), nameof(PlaySettings.DoPlaySettingsGlobalControls))]
//   public static class RimWorld_PlaySettings_DoPlaySettingsGlobalControls
//   {
//     private static void Postfix(WidgetRow row, bool worldView)
//     {
//       if (worldView || row == null) { return; }
//
//       if (!row.ButtonIcon(Textures.ToggleIcon, Mod.Name)) { return; }
//
//       Dialog_Main.Open();
//     }
//   }
// }

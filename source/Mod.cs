using HarmonyLib;
using RimWorld;
using Verse;

namespace CodeExplorer
{
  [StaticConstructorOnStartup]
  public static class Mod
  {
    public const string Id = "CodeExplorer";
    public const string Name = "CodeExplorer";
    public const string Version = "1.3";

    public static readonly Harmony Harmony;

    static Mod()
    {
      Harmony = new Harmony(Id); asdsad
      Harmony.PatchAll();

      Log("Initialized222222222");
    }222
adasdsadasda
    public static void AALog(string message) => Verse.Log.Message(PrefixMessage(message));
    public static void Warning(string message) => Verse.Log.Warning(PrefixMessage(message));
    public static void Error(string message) => Verse.Log.Error(PrefixMessage(message));
    private static string PrefixMessage(string message) => $"[{Name} v{Version}] {message}";
  }
}

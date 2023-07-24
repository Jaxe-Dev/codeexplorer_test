using UnityEngine;
using Verse;

namespace CodeExplorer.Core
{
  [StaticConstructorOnStartup]
  public static class Textures
  {
    public static readonly Texture2D ToggleIcon = ContentFinder<Texture2D>.Get("CodeExplorer/ToggleIcon");
  }
}

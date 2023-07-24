using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Verse;

namespace CodeExplorer.Core
{
  public class Dialog_Main : Window
  {
    private const float SectionPadding = 8f;
    private const float ScrollbarWidth = 20f;

    private static readonly Dialog_Main Instance = new Dialog_Main();
    private Vector2 _scrollPosition;

    private readonly Type Root;
    private readonly List<Type> RootList;

    public override Vector2 InitialSize => new Vector2(UI.screenWidth * 0.8f, UI.screenHeight * 0.8f);

    private Dialog_Main()
    {
      Root = null;
      RootList = GetRootList().ToList();
    }

    private IEnumerable<Type> GetRootList()
    {
      if (Root == null)
      {
        // return LoadedModManager.RunningMods.Select(mod => mod.assemblies.loadedAssemblies);
        return GenTypes.AllTypes;
      }

      return Root.GetNestedTypes();
    }

    public static void Open()
    {
      if (Instance.IsOpen) { return; }
      Find.WindowStack.Add(Instance);

      foreach (var mod in LoadedModManager.RunningMods)
      {
        foreach (var assembly in mod.assemblies.loadedAssemblies)
        {
          Mod.Warning($"[{mod.PackageId}] ======= [{assembly}]");
        }
      }
    }

    public override void DoWindowContents(Rect rect)
    {
      rect.xMax -= ScrollbarWidth;

      var l = new Listing_Standard();

      var font = Text.Font;
      Text.Font = GameFont.Tiny;

      var lineHeight = Text.LineHeight + l.verticalSpacing;
      var count = RootList.Count;
      var filterViewRect = new Rect(0f, 0f, rect.width - ScrollbarWidth, count * lineHeight);

      Widgets.BeginScrollView(rect, ref _scrollPosition, filterViewRect);
      l.Begin(new Rect(0, _scrollPosition.y, filterViewRect.width, rect.height));

      var startIndex = (int) (_scrollPosition.y / lineHeight);
      var indexRange = Math.Min((int) (rect.height / lineHeight) + 1, count);
      var endIndex = startIndex + indexRange;

      if (startIndex >= 0 && endIndex <= RootList.Count)
      {
        for (var i = startIndex; i < endIndex; i++)
        {
          l.ButtonText(RootList[i].FullName);
        }
      }

      l.End();
      Widgets.EndScrollView();

      Text.Font = font;
    }
  }
}

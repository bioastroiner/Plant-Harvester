using UnityEngine;
using System.Collections;
using System;

public class GUIHelper
{
    public static GUIHandler gui = GUIHandler.Instance;

    public static GameObject DrawInfo(Vector2 pos,string txt,object source)
    {
        var p = gui.DrawPanel(pos,source);
        var t = gui.DrawText(pos,txt,source);
        t.transform.SetParent(p.transform);
        p.transform.localScale = Vector2.one * 0.5f;
        return p;
    }

    public static GameObject OpenDropDownWindow(Vector2 pos,UnityEngine.Object source)
    {
        return gui.DrawWindowLayout(GUIHandler.Instance.guis.guiDropMenu, pos);
    }
    public static void CloseWindow()
    {

    }
}

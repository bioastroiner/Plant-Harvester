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

    static ParsedData<GameObject> window;

    public static void OpenWindow(Vector2 pos, object source)
    {
        gui.DrawPanel(pos,source);
    }
    public static void CloseWindow()
    {

    }
}

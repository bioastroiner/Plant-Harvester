using UnityEngine;
using System.Collections;
using System;

public class GUIHelper
{ 
    public static GameObject DrawInfo(Vector2 pos,string txt,object source)
    {
        var p = GUIHandler.Instance.DrawPanel(pos,source);
        var t = GUIHandler.Instance.DrawText(pos,txt,source);
        t.transform.SetParent(p.transform);
        p.transform.localScale = Vector2.one * 0.5f;
        return p;
    }
}

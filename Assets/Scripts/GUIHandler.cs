using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GUIHandler : MonoBehaviour
{
    [HideInInspector]
    public static GUIHandler Instance { get { return GameObject.Find("Prisistant GameObject").GetComponent<GUIHandler>(); } }

    public GameObject UI_component;
    public GameObject UI_txt;

    public Canvas canvas;

    List<KeyValuePair<object, GameObject>> cachedUIs = new List<KeyValuePair<object, GameObject>>();

    public GameObject AddUI(GameObject g,object source)
    {
        GameObject go = Instantiate(g, canvas.transform);
        cachedUIs.Add(new KeyValuePair<object, GameObject>(source,go));
        return go;
    }
    public GameObject DrawPanel(Vector2 pos, object source)
    {
        GameObject g = AddUI(UI_component,source);
        g.transform.position = pos;
        return g;
    }

    public GameObject DrawText(Vector2 pos,string txt, object source)
    {
        GameObject g = AddUI(UI_txt,source);
        g.transform.position = pos;
        g.GetComponent<Text>().text = txt;
        return g;
    }

    public void Clean(object source)
    {
        foreach (var g in cachedUIs)
        {
            if(source == g.Key)
            {
                Destroy(g.Value);
                continue;
            }
        }
    }

}

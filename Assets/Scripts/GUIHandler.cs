using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GUIHandler : MonoBehaviour
{
    [HideInInspector]
    public static GUIHandler Instance { get { return GameObject.Find("Prisistant GameObject").GetComponent<GUIHandler>(); } }

    public Canvas canvas;

    List<KeyValuePair<object, GameObject>> cachedUIs = new List<KeyValuePair<object, GameObject>>();

    public Dictionary<GameObject,GUIWindow> windowsOpened = new Dictionary<GameObject,GUIWindow>();

    [SerializeField]
    public GUIBank guis = new GUIBank();

    public GameObject AddUI(GameObject g,object source)
    {
        GameObject go = Instantiate(g, canvas.transform);
        cachedUIs.Add(new KeyValuePair<object, GameObject>(source,go));
        return go;
    }
    public GameObject DrawPanel(Vector2 pos, object source)
    {
        GameObject g = AddUI(guis.guiGenericPanel,source);
        g.transform.position = pos;
        return g;
    }

    public GameObject DrawText(Vector2 pos,string txt, object source)
    {
        GameObject g = AddUI(guis.guiGenericText,source);
        g.transform.position = pos;
        g.GetComponent<Text>().text = txt;
        return g;
    }

    public GameObject DrawWindowLayout(GameObject window,Vector2 pos)
    {
        try
        {
            windowsOpened.Add(window, new GUIWindow());
        }
        catch (System.Exception e)
        {
            // NO duplicated window allowed
            return null;
        }

        var g = Instantiate(window, canvas.transform);
        var w = g.GetComponent<GUIWindow>();

        Node.canDrawInfo = false;

        // this is the template for further refrences not gui gameobject in the scene (this is our prefab simply)
        w.guiWindow = window;
        w.SetPosition(pos);
        w.Open();
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
    public void Clean()
    {
        foreach (var g in cachedUIs)
        {
            Destroy(g.Value);
        }
        cachedUIs.Clear();
    }
    [System.Serializable]
    public class GUIBank
    {
        // Generic guis
        public GameObject guiGenericPanel;
        public GameObject guiGenericText;

        // Specialized guis
        public GameObject guiDropMenu;
    }
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class GUIWindow : MonoBehaviour
{
    // this is the template for further refrences not gui gameobject in the scene (this is our prefab simply)
    public GameObject guiWindow;

    public bool isOpened;

    public Button ApplyButton;

    public void Close()
    {
        isOpened = false;

        // this is in a Bad place Move it later
        Node.canDrawInfo = true;
        Destroy(gameObject);
        foreach (var p in GUIHandler.Instance.windowsOpened)
        {
            if (p.Key == guiWindow)
            {
                try
                {
                    GUIHandler.Instance.windowsOpened.Remove(p.Key);
                    break;
                }
                catch(System.Exception e)
                {
                    return;
                }
                
            }
        }
        
        
    }

    public void Open()
    {
        isOpened = true;

    }

    public void SetPosition(Vector2 pos)
    {
        transform.position = pos;
    }
}

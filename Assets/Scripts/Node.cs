using UnityEngine;
using System.Collections;

public class Node : MonoBehaviour
{
    public Mesh mesh { get { return GetComponent<MeshFilter>().mesh; } }
    public Collider collider { get { return GetComponent<MeshCollider>(); } }
    public Vector2 pos { get
        {
            string[] s = gameObject.name.Split(new char[2] { ':', '|' });;
            return new Vector2(s[1].ToCharArray()[0], s[2].ToCharArray()[0]);
        }
    }

    ParsedData<GameObject> goData;

    public void HighLight(bool b = true)
    {
        GetComponent<MeshRenderer>().enabled = b;
    }

    private void OnMouseEnter()
    {
        HighLight();
        var g = GUIHelper.DrawInfo(Input.mousePosition, $"{name}", this);
        goData = new ParsedData<GameObject>(g);
    }

    private void OnMouseExit()
    {
        HighLight(false);
        GUIHandler.Instance.Clean(this);
    }

    private void OnMouseOver()
    {
        goData.Value().transform.position = Input.mousePosition;
    }

    private void OnMouseDown()
    {
        transform.localScale = Vector3.one * 0.99f;

    }

    private void OnMouseUp()
    {
        transform.localScale = Vector3.one * 1f;

    }

    private void OnMouseDrag()
    {

    }
}

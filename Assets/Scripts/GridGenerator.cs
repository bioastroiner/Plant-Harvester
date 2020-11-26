using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GridGenerator : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        GenerateGrid();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void GenerateGrid()
    {
        GenerateGrid((Vector2)this.transform.position, 10, 10);
    }

    void GenerateGrid(Vector2 startNode, int xSize, int ySize)
    {
        startNode = Vector2.zero;
        for (int x = 0; x < xSize; x++) for (int y = 0; y < ySize; y++)
            {
                GameObject go = new GameObject(string.Format("NODE-:{0}|{1}", x.ToString(), y.ToString()));
                go.transform.SetParent(this.transform);
                go.transform.SetPositionAndRotation(new Vector3(x + this.transform.position.x, transform.position.y,y + this.transform.position.z), Quaternion.identity);
                go.AddComponent<MeshRenderer>().enabled = false;
                go.AddComponent<MeshFilter>();
                
                Color col = new Color();
                switch ((x + y)%2)
                {
                    case 0:
                        col = Color.green;
                        break;
                    case 1:
                        col = Color.gray;
                        break;
                }
                col.a = 0.01f;
                CubeGenerator.makeCube(go,col);
                go.AddComponent<MeshCollider>().sharedMesh = go.GetComponent<MeshFilter>().mesh;
                go.AddComponent<Node>();
                Vector2 v = go.GetComponent<Node>().pos;
            }
    }
    private void OnDrawGizmos()
    {
        
    }
}

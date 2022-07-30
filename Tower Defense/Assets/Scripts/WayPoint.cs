using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public Waypoint exploreFrom;
    Vector2Int gridPos;
    const int gridSize = 10;
    public bool isExplored = false;

    public int GetGridSize() 
    {
        return gridSize;
    }

    public Vector2Int GetGridPos()
    {
        return new Vector2Int
            (
                Mathf.RoundToInt(transform.position.x / gridSize),
                Mathf.RoundToInt(transform.position.z / gridSize)
            );
    }

    public void SetTopColor(Color color)
    {
        MeshRenderer topMeshRenderer = transform.Find("Quad Top").GetComponent<MeshRenderer>();
        topMeshRenderer.material.color = color;
    }
}

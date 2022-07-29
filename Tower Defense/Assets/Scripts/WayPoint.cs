using UnityEngine;

public class Waypoint : MonoBehaviour
{
    Vector2Int gridPos;
    const int gridSize = 10;
    public bool isExplored = false;

    public int GetGridSize()
    {
        return gridSize;
    }

    //Метод позволяет получить координаты куба
    public Vector2Int GetGridPos()
    {
        return new Vector2Int
            (
                Mathf.RoundToInt(transform.position.x / gridSize),
                Mathf.RoundToInt(transform.position.z / gridSize)
            );
    }

    //Метод перекрашивающий верхушку куба
    public void SetTopColor(Color color)
    {
        MeshRenderer topMeshRenderer = transform.Find("Quad Top").GetComponent<MeshRenderer>();
        topMeshRenderer.material.color = color;
    }
}

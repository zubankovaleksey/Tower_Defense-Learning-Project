using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] Waypoint startPoint, endPoint;
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();

    Vector2Int[] directions =
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };

    void Start()
    {
        LoadBlocks();
        SetColorEndStart();
        ExploreNearPoints();
    }

    void ExploreNearPoints()
    {
        foreach (Vector2Int direction in directions)
        {
            Vector2Int nearPointCoordinates = startPoint.GetGridPos() + direction;
            try
            {
                grid[nearPointCoordinates].SetTopColor(Color.blue);
            }
            catch
            {
                Debug.LogWarning("Куб: " + nearPointCoordinates + "отсутствует");
            }
            print("проверено"+nearPointCoordinates);
        }
    }

    void SetColorEndStart()
    {
        startPoint.SetTopColor(Color.green);
        endPoint.SetTopColor(Color.black);
    }
    private void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<Waypoint>();
        foreach (Waypoint waypoint in waypoints)
        {
            Vector2Int gridPos = waypoint.GetGridPos();

            if (grid.ContainsKey(gridPos))
                Debug.Log("Alert" + waypoint);
            else
            { 
                grid.Add(waypoint.GetGridPos(), waypoint);
            }
        }
    }
}
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] Waypoint startPoint, endPoint;
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    List<Waypoint> path = new List<Waypoint>();
    Queue<Waypoint> queue = new Queue<Waypoint>();
    bool isRuning = true;
    Waypoint searchPoint;

    Vector2Int[] directions =
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };

    public List<Waypoint> GetPath()
    {
        if (path.Count == 0)
        {
            LoadBlocks();
            PathFind();
            CreatePath();
        }
            return path;
    }

    void LoadBlocks()
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

    void PathFind()
    {
        queue.Enqueue(startPoint);
        while (queue.Count > 0 && isRuning == true)
        {
            searchPoint = queue.Dequeue();
            searchPoint.isExplored = true;
            CheckForEndpoint();
            ExploreNearPoints();
        }
        SetColorEndStart();
    }

    void CheckForEndpoint()
    {
        if (searchPoint == endPoint)
        {
            isRuning = false;
        }
    }

    void ExploreNearPoints()
    {
        if (!isRuning)
        {
            return;
        }
        
        foreach (Vector2Int direction in directions)
        {
            Vector2Int nearPointCoordinates = searchPoint.GetGridPos() + direction;

            if (grid.ContainsKey(nearPointCoordinates))
            {
                Waypoint nearPoint = grid[nearPointCoordinates];
                AddPointQuee(nearPoint);
            }
        }
    }

    void AddPointQuee(Waypoint nearPoint)
    {
        if (nearPoint.isExplored || queue.Contains(nearPoint))
        {
            return;
        }
        else
        {
            nearPoint.SetTopColor(Color.blue);
            queue.Enqueue(nearPoint);
            nearPoint.exploreFrom = searchPoint;
        }
    }

    void SetColorEndStart()
    {
        startPoint.SetTopColor(Color.green);
        endPoint.SetTopColor(Color.black);
    }

    void CreatePath()
    {
        path.Add(endPoint);
        Waypoint prevPoint = endPoint.exploreFrom;
        while (prevPoint != startPoint)
        {
            prevPoint.SetTopColor(Color.gray);
            path.Add(prevPoint);
            prevPoint = prevPoint.exploreFrom;
        }
        path.Add(startPoint);
        path.Reverse();
    }
}
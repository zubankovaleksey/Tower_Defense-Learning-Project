using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] Waypoint startPoint, endPoint;
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Queue<Waypoint> queue = new Queue<Waypoint>();
    bool isRuning = true;

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
        PathFind();
        //ExploreNearPoints();
    }

    //Метод поиска пути, от начальной точки
    void PathFind()
    {
        queue.Enqueue(startPoint);
        while (queue.Count > 0 && isRuning == true)
        {
            Waypoint searchPoint = queue.Dequeue();
            searchPoint.isExplored = true;
            print("Исследовать соседние клетки из: " + searchPoint);
            CheckForEndpoint(searchPoint);
            ExploreNearPoints(searchPoint);
        }
        SetColorEndStart();
        print("Можем сгенерировать путь?");
    }

    //Метод объявляющий о нахождении финальной точки
    void CheckForEndpoint(Waypoint searchPoint)
    {
        if (searchPoint == endPoint)
        {
            print("Алгоритм нашел финальную точку");
            isRuning = false;
        }
    }

    //Метод исследующий ближайшую точку, до нахождения финальной точки
    void ExploreNearPoints(Waypoint from)
    {
        if (!isRuning)
        {
            return;
        }
        
        foreach (Vector2Int direction in directions)
        {
            Vector2Int nearPointCoordinates = from.GetGridPos() + direction;

            try
            {
                Waypoint nearPoint = grid[nearPointCoordinates];
                AddPointQuee(nearPoint);
            }
            catch
            {

            }
        }
    }

    //Метод добавляющий точку в очередь
    void AddPointQuee(Waypoint nearPoint)
    {
        //Если ближайшая не точка исследована, добавляем ее в очередь
        if (nearPoint.isExplored)
        {
            return;
        }
        else
        {
            print("Добавить в очередь: " + nearPoint);
            nearPoint.SetTopColor(Color.blue);
            queue.Enqueue(nearPoint);
        }
    }

    //Метод устанавливающий цвета для начальной и конечной точек
    void SetColorEndStart()
    {
        startPoint.SetTopColor(Color.green);
        endPoint.SetTopColor(Color.black);
    }

    //Метод загрузки блоков в словарь
    void LoadBlocks()
    {
        //Поиск объектов с типом Waypoint
        var waypoints = FindObjectsOfType<Waypoint>();

        //Цикл позволяющий помещающий найденные объекты в словарь
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
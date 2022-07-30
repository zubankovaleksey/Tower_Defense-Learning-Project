 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    PathFinder pathFinder;
    void Start()
    {
        pathFinder = FindObjectOfType<PathFinder>();
        var path = pathFinder.GetPath();
        StartCoroutine(EnemyMove(path));
    }

    IEnumerator EnemyMove(List<Waypoint> path)
    {
        foreach (Waypoint waypoint in path)
        {
            transform.LookAt(waypoint.transform.position);
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(2f);
        }
    }
}

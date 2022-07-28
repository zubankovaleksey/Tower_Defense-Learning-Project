using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
   [SerializeField] List<Waypoint> waypoints;

    void Start()
    {
        PrintWaypoinName();
        StartCoroutine(PrintWaypoinName());
    }

     IEnumerator PrintWaypoinName()
    {
        foreach (Waypoint waypoint in waypoints)
        {
            Debug.Log(waypoint);
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(1f);
        }
    }
}

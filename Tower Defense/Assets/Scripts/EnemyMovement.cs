using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
   [SerializeField] List<WayPoint> wayPoints;

    void Start()
    {
        PrintWayPoints();
        StartCoroutine(PrintWayPoints());
    }

     IEnumerator PrintWayPoints()
    {
        foreach (WayPoint wayPoint in wayPoints)
        {
            Debug.Log(wayPoint);
            transform.position = wayPoint.transform.position;
            yield return new WaitForSeconds(1f);
        }
    }
}

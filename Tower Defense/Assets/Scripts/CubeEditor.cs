using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Waypoint))]

public class CubeEditor : MonoBehaviour
{
    Waypoint waypoint;
    void Awake()
    {
        waypoint = GetComponent<Waypoint>();
    }

    void Update()
    {
        SnapToGrid();
        UpdateLabe();
    }

    void SnapToGrid()
    {
        int gridSize = waypoint.GetGridSize();
        transform.position = new Vector3(waypoint.GetGridPos().x * gridSize, 0f, waypoint.GetGridPos().y * gridSize);
    }

    void UpdateLabe()
    {
        TextMesh lable = GetComponentInChildren<TextMesh>();
        string lableName = waypoint.GetGridPos().x + "," + waypoint.GetGridPos().y;
        lable.text = lableName;
        gameObject.name = lableName;
    }

}

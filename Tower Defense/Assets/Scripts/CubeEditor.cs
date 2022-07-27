using UnityEngine;

[ExecuteInEditMode]

public class CubeEditor : MonoBehaviour
{
    [SerializeField] [Range(1f,20f)]int gridScale = 10;

    TextMesh lable;

    private void Update()
    {
        Vector3 snapPos;

        snapPos.x = Mathf.Round(transform.position.x/gridScale) * gridScale;
        snapPos.y = 0f;
        snapPos.z = Mathf.Round(transform.position.z / gridScale) * gridScale;
        transform.position = snapPos;

        lable = GetComponentInChildren<TextMesh>();
        string lableName = snapPos.x / gridScale + "," + snapPos.z / gridScale;
        lable.text = lableName;
        gameObject.name = lableName;
    }
}

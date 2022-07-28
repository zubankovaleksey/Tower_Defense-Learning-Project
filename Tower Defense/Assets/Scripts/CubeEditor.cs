using UnityEngine;

//Работоспособность скрипта во время редактирования в Unity
[ExecuteInEditMode]
//Принудительное добавление WayPoint
[RequireComponent(typeof(Waypoint))]

public class CubeEditor : MonoBehaviour
{
    Waypoint waypoint;
    //Подключаемся к Waypoint для получения координат куба
    void Awake()
    {
        waypoint = GetComponent<Waypoint>();
    }

    void Update()
    {
        SnapToGrid();
        UpdateLabe();
    }
    //Метод позволяющий передвигать объекты по сетке
    private void SnapToGrid()
    {
        int gridSize = waypoint.GetGridSize();
        transform.position = new Vector3(waypoint.GetGridPos().x * gridSize, 0f, waypoint.GetGridPos().y * gridSize);
    }
    //Метод отображающий текущие координаты куба
    void UpdateLabe()
    {
        int gridSize = waypoint.GetGridSize();
        //Подключаемся к компоненту отвечающему за отображение текста
        TextMesh lable = GetComponentInChildren<TextMesh>();
        //Получаем информацию из wayPoint о местонахождении куба
        string lableName = waypoint.GetGridPos().x + "," + waypoint.GetGridPos().y;
        lable.text = lableName;
        //Дублируем координаты куба в названии объекта
        gameObject.name = lableName;
    }

}

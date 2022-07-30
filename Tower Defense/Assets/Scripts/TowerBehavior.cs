using UnityEngine;

public class TowerBehavior : MonoBehaviour
{
    [SerializeField] Transform towerTop;
    [SerializeField] Transform targetEnemy;

    private void Update()
    {
        towerTop.LookAt(targetEnemy);
    }
}

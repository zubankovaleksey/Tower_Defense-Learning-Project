using UnityEngine;

public class TowerBehavior : MonoBehaviour
{
    [SerializeField] Transform towerTop;
    [SerializeField] Transform targetEnemy;
    [SerializeField] float shootRange;
    [SerializeField] ParticleSystem bulletParticals; 

    private void Update()
    {
        towerTop.LookAt(targetEnemy);
        if (targetEnemy)
        {
            Fire();
        }
        else
        {
            Shoot(false);
        }
    }

    void Fire()
    {
        float DistantToEnemy = Vector3.Distance(targetEnemy.position, gameObject.transform.position);
        if (DistantToEnemy <= shootRange)
        {
            Shoot(true);
        }
        else
        {
            Shoot(false);
        }
    }

    void Shoot(bool isActive)
    {
        var emission = bulletParticals.emission;
        emission.enabled = isActive;
    }
}

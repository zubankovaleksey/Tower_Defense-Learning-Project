using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int healthPoint = 10;

    void Start()
    {
        
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        print("Получен урон");
        if (healthPoint <= 0)
        {
            DestroyEnemy();
        }
        
    }

    void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    void ProcessHit()
    {
        healthPoint = healthPoint - 1;
    }
}

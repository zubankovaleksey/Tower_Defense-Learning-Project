using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    void OnParticleCollision(GameObject other)
    {
        print("Получен урон");
    }
}

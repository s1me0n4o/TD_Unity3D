using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] GameObject ps;
    public int health = Enemy.health;
    public int hitCounter = 0;

    public void Collided(bool isCollided)
    {
        if (isCollided)
        {
            hitCounter += 1;
            if (health - hitCounter <= 0)
            {
                Destroy(gameObject);
                GameObject EffectInsert = Instantiate(ps, gameObject.transform.position, Quaternion.identity);
                Destroy(EffectInsert, 5f);
            }
        }
    }
}
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] GameObject ps;
    public float health = Enemy.health;
    public int hitCounter = 0;
    public int enemyCurrency = Enemy.enemyCurrency;

    public void Collided(bool isCollided)
    {
        if (isCollided)
        {
            hitCounter += 1;
            if (health - hitCounter <= 0)
            {
                DestroyEnemy();
            }
        }
    }

    public void DestroyEnemy()
    {
        PlayerStatistics.money += enemyCurrency;

        Destroy(gameObject);
        GameObject EffectInsert = Instantiate(ps, gameObject.transform.position, Quaternion.identity);
        Destroy(EffectInsert, 5f);
    }

}
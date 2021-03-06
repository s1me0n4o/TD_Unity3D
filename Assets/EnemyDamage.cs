﻿using UnityEngine;
using UnityEngine.UI;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] GameObject ps;
    public float health = Enemy.health;
    public int hitCounter = 0;
    public int enemyCurrency = Enemy.enemyCurrency;

    public Image HealthBar;
    
    public void Collided(bool isCollided)
    {
        if (isCollided)
        {
            GetDMG();
        }
    }

    private void GetDMG()
    {
        hitCounter += 1;
        HealthBar.fillAmount = 1f / (health - hitCounter);
        if (health - hitCounter <= 0)
        {
            DestroyEnemy();
        }
    }

    public void DestroyEnemy()
    {
        PlayerStatistics.money += enemyCurrency;

        Destroy(gameObject);
        WaveSpowner.enemyAliveCount--;
        GameObject EffectInsert = Instantiate(ps, gameObject.transform.position, Quaternion.identity);
        Destroy(EffectInsert, 5f);

    }

}
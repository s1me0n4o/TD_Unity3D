using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] GameObject ps;
    private int health = Enemy.health;
    private int hitCounter = 0;
    
   private void OnParticleCollision(GameObject other)
    {
        hitCounter += 1;
        if (health - hitCounter <= 0)
        {
            Destroy(gameObject);
            Instantiate(ps, gameObject.transform.position, Quaternion.identity);
            other.SetActive(false);
            
         //TODO destroy the PS after 3-5 sec

            //Invoke("DestroyPS(ps)", 5f);
            if(ps && ps.GetComponent<ParticleSystem>().IsAlive())
            {
                Destroy(ps, 3f);
            }
            return;
        }

    }

    //TODO Destroy the particle effect


    //public void DestroyPS(GameObject ps)
    //{
    //    DestroyImmediate(ps, true);
    //}
}

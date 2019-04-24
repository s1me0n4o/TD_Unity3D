using System;
using UnityEngine;

public class Towers : MonoBehaviour
{
    [Header("Laser")]
    public bool useLaser = false;
    public ParticleSystem impactEffect;
    public LineRenderer lineRenderer;
    public Light impactLight;
    public float slowPercent = 0.5f;

    [Header("Attributes")]
    [SerializeField] float range = 6f;
    public float damageOverTime = 0.5f;

    [Header("Instances")]
    [SerializeField] GameObject firePoint;
    [SerializeField] float fireCountDown = 0f;

    private float fireRate = 1f;
    private Transform target;
    private EnemyDamage targetEnemyForDMG;
    private Enemy targetEnemy;

    void Start()
    {
        InvokeRepeating("UpdateEnemy", 0f, 0.5f); // string ref
    }

    void Update()
    {
        if (target == null)
        {
            if (useLaser)
            {
                if (lineRenderer.enabled)
                {
                    lineRenderer.enabled = false;
                    impactEffect.Stop();
                    impactLight.enabled = false;
                }
            }

            return;
        }
        RotateTower();

        if (useLaser)
        {
            Laser();
        }
        else
        {
            if (fireCountDown <= 0)
            {
                Shoot();
                fireCountDown = 1f / fireRate;
            }
            fireCountDown -= Time.deltaTime;
        }
    }

    private void Laser()
    {
        //slow
        targetEnemy.SlowEnemy(slowPercent);
        
        //damage
        //TODO Change the DMG
        targetEnemyForDMG.health = targetEnemyForDMG.health * ( (1f - damageOverTime) * Time.deltaTime);
        print(targetEnemyForDMG.health);


        if (targetEnemyForDMG.health <= 0)
        {
            targetEnemyForDMG.DestroyEnemy(); 
        }

        //graphics
        if (!lineRenderer.enabled)
        {
            lineRenderer.enabled = true;
            impactEffect.Play();
            impactLight.enabled = true;
        }

        Vector3 dirFromEnemyToTower = firePoint.transform.position - target.position;

        impactEffect.transform.position = target.position + dirFromEnemyToTower.normalized * 0.5f;
        impactEffect.transform.rotation = Quaternion.LookRotation(dirFromEnemyToTower);
        
        //seting the fire point
        lineRenderer.SetPosition(0, firePoint.transform.position);
        //setting the target
        lineRenderer.SetPosition(1, target.position);


    }

    void UpdateEnemy()
    {
        float shortestDistanceToEnemy = Mathf.Infinity;
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy"); //string reference
        GameObject nearestTarget = null; 

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(this.transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistanceToEnemy)
            {
                shortestDistanceToEnemy = distanceToEnemy;
                nearestTarget = enemy;
            }
        }

        if (nearestTarget != null && shortestDistanceToEnemy <= range)
        {
            target = nearestTarget.transform;
            targetEnemyForDMG = nearestTarget.GetComponent<EnemyDamage>();
            targetEnemy = nearestTarget.GetComponent<Enemy>();
        }
        else
        {
            target = null;
        }
    }

    void RotateTower()
    {
        if (target == null)
        {
            return;
        }
        this.transform.LookAt(target);
    }

    private void Shoot()
    {
        if (target == null)
        {
            return;
        }
        else
        {
            if (Vector3.Distance(this.transform.position, target.transform.position) <= range)
            {
                firePoint.gameObject.SetActive(true);

                GameObject BulletGO = Instantiate(firePoint, firePoint.transform.position, Quaternion.identity);
                Bullet bullet = BulletGO.GetComponent<Bullet>(); ;
                if (bullet != null)
                {
                    bullet.SeekTarget(target);
                }
            }
            else
            {
                firePoint.gameObject.SetActive(false);
            }
        }
    }
    
    //Draw a sphere for the tower range
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}

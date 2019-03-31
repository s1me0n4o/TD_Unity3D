using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Towers : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] float range = 6f;
    [SerializeField] float fireRate = 1f;
    [SerializeField] float fireCountDown = 3f;
    [Header("Instances")]
    [SerializeField] GameObject bullet;
    [SerializeField] Transform firePoint;
    private Transform target;
    
    void Start()
    {
        InvokeRepeating("UpdateEnemy", 0f, 0.5f); // string ref
    }

    void Update()
    {
        RotateTower();

        if (fireCountDown <= 0)
        {
            Shoot();
            fireCountDown = 1f / fireRate;
        }

        fireCountDown -= Time.deltaTime;
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
        Instantiate(bullet, firePoint.position, firePoint.rotation);
    }
    
    //Draw a sphere for the tower range
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}

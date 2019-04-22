using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    public static int health = 3;
    public static int enemyCurrency = 20;

    private Transform target;
    private int waypointIndex = 0;

    void Start()
    {
//setting the first target of our enemy to be the first waypoint in the array   
        target = Waypoints.waypoints[0];
    }

    void Update()
    {
//setting the direction that our enemy should go and appling the movement
        Vector3 dir = target.position - this.transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(this.transform.position, target.position) <= 0.2f)
        {
            if (waypointIndex >= Waypoints.waypoints.Length - 1)
            {
                EndPath();
//Sometimes Destroy needs some time to clean the whole object and if we dont use return we can get index out of range
                return;
            }

//getting next position
            waypointIndex++;
            target = Waypoints.waypoints[waypointIndex];
        }

    }

    void EndPath()
    {
        PlayerStatistics.lives--;
        Destroy(this.gameObject);
    }

}

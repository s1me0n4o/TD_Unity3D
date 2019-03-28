using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public static Transform[] waypoints;

    void Awake()
    {
//setting up the count of the waypoints
        waypoints = new Transform[transform.childCount];

        for (int i = 0; i < waypoints.Length; i++)
        {
//setting the position of each waypoint
            waypoints[i] = transform.GetChild(i);
        }
    }

}

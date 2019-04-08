using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{

    public static BuildManager instance;

    //pick a tower
    public GameObject tower1;
    public GameObject tower2;

    //check if its null at the start
    private GameObject towerToBuild;

    void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than 1 build manager in the scene!");
            return;
        }
        instance = this;
    }

    //call it from other method to change the tower to build
    public void SetTowerToBuild(GameObject tower)
    {
        towerToBuild = tower;
    }

    public GameObject GetTowerToBuild()
    {
        print("towertoBuild");
        return towerToBuild;
    }

}

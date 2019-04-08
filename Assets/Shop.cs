using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void BuildTower1()
    {
        Debug.Log("ok1");   
        //pick tower 1
        buildManager.SetTowerToBuild(buildManager.tower1);
    }

    public void BuildTower2()
    {
        Debug.Log("ok2");
        //pick tower 2
        buildManager.SetTowerToBuild(buildManager.tower2); 
    }
}

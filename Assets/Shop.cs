using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;
    public TowerBluePrint tower1;
    public TowerBluePrint tower2;
    public TowerBluePrint tower3;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectTower1()  
    {
        Debug.Log("You have selected Frieza");
        buildManager.SelectTowerToBuild(tower1);
    }

    public void SelectTower2()
    {
        Debug.Log("You have selected Bou");
        buildManager.SelectTowerToBuild(tower2); 
    }

    public void SelectTower3()
    {
        Debug.Log("You have selected Bou");
        buildManager.SelectTowerToBuild(tower3);
    }
}

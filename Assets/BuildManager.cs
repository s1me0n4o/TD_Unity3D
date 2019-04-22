using UnityEngine;

public class BuildManager : MonoBehaviour
{

    public static BuildManager instance;

    ////pick a tower
    //public GameObject tower1;
    //public GameObject tower2;

    //check if its null at the start
    private TowerBluePrint towerToBuild;
    private Vector3 towerToBuildPos;

    void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than 1 build manager in the scene!");
            return;
        }
        instance = this;
    }

    public bool CanBuld { get { return towerToBuild != null; } }
    public bool HasMoney { get { return PlayerStatistics.money >= towerToBuild.price; } }


    public void SelectTowerToBuild(TowerBluePrint tower)
    {
        towerToBuild = tower;
    }

    public void BuildOn(Grid grid)
    {
        if (PlayerStatistics.money < towerToBuild.price)
        {
            print("Not Enough Money!");
            return;
        }

        PlayerStatistics.money -= towerToBuild.price; 

        GameObject tower = Instantiate(towerToBuild.prefab, grid.transform.position + towerToBuild.offsetPos, Quaternion.identity);
        grid.tower = tower;

        print("Money Left " + PlayerStatistics.money);
    }
}

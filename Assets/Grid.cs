using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    [SerializeField] Color hoverColor = Color.blue;
   // [SerializeField] GameObject tower;

    BuildManager buildManager;

    //storing the mesh renderer material color in var so we can cash it at the start of our game
    private Renderer rend;
    private Color startColor;

    public bool isTaken = false;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
    }

    void OnMouseEnter()
    {
        if (buildManager.GetTowerToBuild() == null)
        {
            return;
        }
        else
        {
            rend.material.color = hoverColor;
        }
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }

    void OnMouseDown()
    {
        if (buildManager.GetTowerToBuild() == null)
        {
            return;
        }
        else
        {
            if (!isTaken && Input.GetMouseButtonDown(0))
            {
                GameObject newTower = buildManager.GetTowerToBuild();
                newTower = (GameObject)Instantiate(newTower, new Vector3(this.transform.position.x, 2f, this.transform.position.z), Quaternion.identity);
                isTaken = true;
            }
        }     
    }
}

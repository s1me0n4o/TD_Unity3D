using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class Grid : MonoBehaviour
{
    [SerializeField] Color hoverColor = Color.blue;
    [SerializeField] Color notEnoughMoneyColor = Color.red;

    BuildManager buildManager;

    //storing the mesh renderer material color in var so we can cash it at the start of our game
    private Renderer rend;
    private Color startColor;

    [Header("Optinal prefab")]
    public GameObject tower;

    public Vector3 posOffset;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
    }

    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (!buildManager.CanBuld)
        {
            return;
        }

        if (!buildManager.HasMoney)
        {
            rend.material.color = notEnoughMoneyColor;
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
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (!buildManager.CanBuld)
        {
            return;
        }

        if (tower != null)
        {
            print("Cant Build There!");
            return;
        }
        if (Input.GetMouseButtonDown(0))
        {
            buildManager.BuildOn(this);
        }
    }

}

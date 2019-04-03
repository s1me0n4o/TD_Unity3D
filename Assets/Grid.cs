using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    [SerializeField] Color hoverColor = Color.blue;
    [SerializeField] GameObject tower;

    //storing the mesh renderer material color in var so we can cash it at the start of our game
    private Renderer rend;
    private Color startColor;

    public bool isTaken = false;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    void OnMouseEnter()
    {
        rend.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }

    void OnMouseDown()
    {
        if (!isTaken && Input.GetMouseButtonDown(0))
        {
            Instantiate(tower, new Vector3 (this.transform.position.x, 2f, this.transform.position.z), Quaternion.identity);
            isTaken = true;
        }
     
    }
}

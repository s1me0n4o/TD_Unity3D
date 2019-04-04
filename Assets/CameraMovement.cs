using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    [SerializeField] float scrollSpeed = 15f;
    [SerializeField]  float scrollEdge = 0.1f;
    [SerializeField]  float panSpeed = 5f;
    [SerializeField]  float currentZoom = 0f;
    [SerializeField]  float zoomSpeed = 0.5f;
    [SerializeField]  float zoomRotation = 5f;
    [SerializeField]  float rotateSpeed = 10f;

    [SerializeField]  Vector2 zoomRange = new Vector2(-10f, 10f);
    [SerializeField]  Vector2 zoomAngleRange = new Vector2(20f, 80f);

    private Vector3 initialPosition;
    private Vector3 initialRotation;

    private bool doMovement = true;

    void Start()
    {
        initialPosition = transform.position;
        initialRotation = transform.eulerAngles;
    }


    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            doMovement = !doMovement;   
        }

        if (!doMovement)
        {
            return;
        }

        //mause pan
        if (Input.GetMouseButton(1))
        {
            transform.Translate(Vector3.right * Time.deltaTime * panSpeed * (Input.mousePosition.x - Screen.width * 0.5f) / (Screen.width * 0.5f), Space.World);
            transform.Translate(Vector3.forward * Time.deltaTime * panSpeed * (Input.mousePosition.y - Screen.height * 0.5f) / (Screen.height * 0.5f), Space.World);
        }

        //camera movement by keys
        else
        {
            if (Input.GetKey("d"))
            {
                transform.Translate(Vector3.right * Time.deltaTime * panSpeed, Space.World);
            }
            else if (Input.GetKey("a"))
            {
                transform.Translate(Vector3.right * Time.deltaTime * -panSpeed, Space.World);
            }

            if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - scrollEdge)
            {
                transform.Translate(Vector3.forward * Time.deltaTime * panSpeed, Space.World);
            }
            else if (Input.GetKey("s") || Input.mousePosition.y <= Screen.height * scrollEdge)
            {
                transform.Translate(Vector3.forward * Time.deltaTime * -panSpeed, Space.World);
            }

            if (Input.GetKey("q") || Input.mousePosition.x <= Screen.width * scrollEdge)
            {
                transform.Rotate(Vector3.up * Time.deltaTime * -rotateSpeed, Space.World);
            }
            else if (Input.GetKey("e") || Input.mousePosition.x >= Screen.width - scrollEdge)
            {
                transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed, Space.World);
            }
        }

        // zoom in/out
        currentZoom -= Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * 1000 * zoomSpeed;

        currentZoom = Mathf.Clamp(currentZoom, zoomRange.x, zoomRange.y);

        transform.position = new Vector3(transform.position.x, transform.position.y - (transform.position.y - (initialPosition.y + currentZoom)) * 0.1f, transform.position.z);

        float x = transform.eulerAngles.x - (transform.eulerAngles.x - (initialRotation.x + currentZoom * zoomRotation)) * 0.1f;
        x = Mathf.Clamp(x, zoomAngleRange.x, zoomAngleRange.y);

        transform.eulerAngles = new Vector3(x, transform.eulerAngles.y, transform.eulerAngles.z);
    }
}

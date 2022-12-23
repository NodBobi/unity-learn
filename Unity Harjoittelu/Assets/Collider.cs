using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider : MonoBehaviour
{
    public float movementSpeed = 5.0f;
    public float mouseSensitivity = 2.0f;

    private float verticalRotation = 0;
    private float verticalRotationLimit = 60;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float forwardMovement = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;
        float sideMovement = Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime;

        transform.position += transform.forward * forwardMovement;
        transform.position += transform.right * sideMovement;

        // Handle mouse input
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = -Input.GetAxis("Mouse Y");

        transform.Rotate(0, mouseX * mouseSensitivity, 0);

        verticalRotation -= mouseY * mouseSensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -verticalRotationLimit, verticalRotationLimit);
        Camera.main.transform.localRotation = Quaternion.Euler(-verticalRotation, 0, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Kuutio")
        {
            Debug.Log("Kuutio osui maahan.");
        }
    }
}

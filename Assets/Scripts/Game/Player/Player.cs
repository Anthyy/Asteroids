using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float movementSpeed = 10f; // Units to travel per second
    public float rotationSpeed = 360f; // Amount of rotation per second

    private Rigidbody2D rBody; // Reference to attached Rigidbody2D


    // Use this for initialization
    void Start()
    {
        // Get reference to rigidbody (automatic assignment)
        rBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Control();
    }

    // Control is a custom made function to handle movement
    void Control()
    {
        // MOVEMENT

        // If the up key is pressed
        if (Input.GetKey(KeyCode.UpArrow))
        {
            // Add a force up
            rBody.AddForce(transform.up * movementSpeed);
        }

        // If the down key is pressed
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rBody.AddForce(-transform.up * movementSpeed); // So there isn't a transform.down (or .left) but you can invert them with a minus
        }

        // ROTATION

        // If the left key is pressed
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rBody.rotation += rotationSpeed * Time.deltaTime;
        }

        // If the right key is pressed
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rBody.rotation += rotationSpeed * Time.deltaTime;
        }
    }
}

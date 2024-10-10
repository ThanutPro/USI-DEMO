using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    [SerializeField]
    public float moveSpeed = 2;
    private Vector3 startPosition; // Variable to store the starting position
    private int loopCounter = 0; // Counter to track the number of loops
    private int maxLoops = 8; // Set the number of loops before resetting to start position

    // Start is called before the first frame update
    void Start()
    {
        // Save the initial starting position of the ship
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Move the ship horizontally
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the ship hits a boundary and reverse direction
        if (collision.gameObject.tag == "Boundary")
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
            moveSpeed *= -1;

            // Increment the loop counter
            loopCounter++;

            // Check if 8 loops have been completed
            if (loopCounter >= maxLoops)
            {
                // Reset the ship to its starting position
                transform.position = startPosition;
                // Reset the loop counter
                loopCounter = 0;
            }
        }
    }
}

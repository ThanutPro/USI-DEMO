using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    [SerializeField]
    public float moveSpeed = 2f;
    private Vector3 startPosition; // Variable to store the starting position
    private int loopCounter = 0; // Counter to track the number of loops
    private int maxLoops = 4; // Set the number of loops before respawning

    // Reference to the Enemy Ships prefab
    public GameObject enemyShipsPrefab;

    // Start is called before the first frame update
    void Start()
    {
        // Save the initial starting position of the ship
        startPosition = transform.position;

        // Optionally, you could spawn the enemy ships here if not already in the scene
        // SpawnEnemyShips();
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
        if (collision.gameObject.CompareTag("Boundary"))
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

                // Respawn the enemy ships
                RespawnEnemyShips();
            }
        }
    }

    private void RespawnEnemyShips()
    {
        // Destroy all existing enemy ships
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        // Instantiate a new set of enemy ships
        GameObject newEnemyShips = Instantiate(enemyShipsPrefab, startPosition, Quaternion.identity);

        // Optionally, you can set the parent of the new enemy ships to this object
        newEnemyShips.transform.parent = transform;
    }
}

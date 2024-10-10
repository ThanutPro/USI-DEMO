using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject asteroidPrefab;   // Prefab for the asteroid
    public float spawnInterval = 2f;    // Time between each asteroid spawn
    public float asteroidSpeed = 5f;     // Speed of the asteroid
    public int maxActiveAsteroids = 3;   // Maximum number of active asteroids

    private Camera mainCamera;           // Reference to the main camera

    private void Start()
    {
        // Get the main camera
        mainCamera = Camera.main;

        // Start spawning asteroids at regular intervals
        StartCoroutine(SpawnAsteroids());
    }

    private IEnumerator SpawnAsteroids()
    {
        while (true)
        {
            // Check if the number of active asteroids is less than the maximum allowed
            if (GetActiveAsteroidCount() < maxActiveAsteroids)
            {
                SpawnAsteroid();
            }

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void SpawnAsteroid()
    {
        // Get the screen bounds in world coordinates
        float screenWidth = mainCamera.orthographicSize * mainCamera.aspect * 2;
        float screenHeight = mainCamera.orthographicSize * 2;

        // Calculate a random X position within the screen width
        float randomX = Random.Range(-screenWidth / 2, screenWidth / 2);

        // Set a fixed Y position for spawning (ensure it's above the top of the screen)
        float spawnY = screenHeight / 2 + 1; // Spawn just above the visible screen

        // Alternatively, to spawn below the screen, uncomment the line below
        // float spawnY = -screenHeight / 2 - 1; // Spawn just below the visible screen

        Vector2 spawnPosition = new Vector2(randomX, spawnY);

        // Instantiate the asteroid
        GameObject newAsteroid = Instantiate(asteroidPrefab, spawnPosition, Quaternion.identity);

        // Set the asteroid's velocity to move it downward
        Rigidbody2D rb = newAsteroid.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -asteroidSpeed);
    }

    private int GetActiveAsteroidCount()
    {
        // Find all active asteroids in the scene
        return GameObject.FindGameObjectsWithTag("Asteroid").Length;
    }
}

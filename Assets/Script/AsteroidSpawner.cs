using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject asteroidPrefab;   // Prefab for the asteroid
    public float spawnInterval = 2f;    // Time between each asteroid spawn
    public float asteroidSpeed = 5f;     // Speed of the asteroid
    public int maxActiveAsteroids = 3;   // Maximum number of active asteroids
    public float minimumSpawnDistance = 2f; // Minimum distance between asteroids

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

        Vector2 spawnPosition = new Vector2(randomX, spawnY);

        // Check if the spawn position is too close to any existing asteroids
        if (IsPositionValid(spawnPosition))
        {
            // Instantiate the asteroid
            GameObject newAsteroid = Instantiate(asteroidPrefab, spawnPosition, Quaternion.identity);

            // Set the asteroid's velocity to move it downward
            Rigidbody2D rb = newAsteroid.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(0, -asteroidSpeed);
        }
    }

    private bool IsPositionValid(Vector2 position)
    {
        // Get all active asteroids
        GameObject[] asteroids = GameObject.FindGameObjectsWithTag("Asteroid");

        // Check distance to existing asteroids
        foreach (GameObject asteroid in asteroids)
        {
            if (Vector2.Distance(position, asteroid.transform.position) < minimumSpawnDistance)
            {
                return false; // Position is too close to an existing asteroid
            }
        }
        return true; // Position is valid for spawning
    }

    private int GetActiveAsteroidCount()
    {
        // Find all active asteroids in the scene
        return GameObject.FindGameObjectsWithTag("Asteroid").Length;
    }
}

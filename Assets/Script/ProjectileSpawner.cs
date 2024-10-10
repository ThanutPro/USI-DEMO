using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    public GameObject[] enemyProjectiles; // Array of different colored projectile prefabs
    public float spawnTimer;
    public float spawnMax = 10f;
    public float spawnMin = 5f;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the spawn timer to a random value between spawnMin and spawnMax
        spawnTimer = Random.Range(spawnMin, spawnMax);
    }

    // Update is called once per frame
    void Update()
    {
        // Decrease spawnTimer by the time passed since the last frame
        spawnTimer -= Time.deltaTime;

        // Check if the timer has reached 0 or below
        if (spawnTimer <= 0)
        {
            // Randomly select a projectile prefab from the array
            int randomIndex = Random.Range(0, enemyProjectiles.Length);

            // Spawn the randomly selected projectile
            Instantiate(enemyProjectiles[randomIndex], transform.position, Quaternion.identity);

            // Reset the spawn timer to a new random value between spawnMin and spawnMax
            spawnTimer = Random.Range(spawnMin, spawnMax);
        }
    }
}

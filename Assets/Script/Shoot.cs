using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField]
    public GameObject projectilePrefab; // Prefab for the projectile
    public float shootCooldown = 0.2f; // Cooldown time in seconds
    private float lastShootTime = 0f; // Time when the last shot was fired

    // Update is called once per frame
    void Update()
    {
        // Check if the cooldown period has passed
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= lastShootTime + shootCooldown)
        {
            // Fire the projectile
            Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            // Update the lastShootTime to the current time
            lastShootTime = Time.time;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    public float moveSpeed = 10f;
    public GameObject explosionPrefab;
    private PointManager pointManager;

    AudioManager audioManager;

    // Set a fixed explosion duration in seconds
    public float explosionDuration = 2f;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start()
    {
        pointManager = GameObject.Find("PointManager").GetComponent<PointManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // Move the projectile upwards
        transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the projectile collides with an enemy
        if (collision.gameObject.CompareTag("Enemy"))
        {
            HandleCollision(collision, 50, audioManager.ExplodeEnemy);
        }

        // Check if the projectile collides with an asteroid
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            HandleCollision(collision, 20, audioManager.ExplodeAsteroid); // Use different score and sound for asteroid
        }

        // Check if the projectile collides with the boundary
        if (collision.gameObject.CompareTag("Boundary"))
        {
            Destroy(gameObject);
        }
    }

    // General method to handle collisions with enemies and asteroids
    private void HandleCollision(Collider2D collision, int scoreValue, AudioClip explosionSound)
    {
        // Play sound effect and instantiate explosion
        audioManager.PlaySFX(explosionSound);
        GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);

        // Destroy the asteroid/enemy and the projectile
        Destroy(collision.gameObject);
        pointManager.UpdateScore(scoreValue);
        Destroy(gameObject);

        // Destroy the explosion after a fixed duration
        Destroy(explosion, explosionDuration);
    }
}

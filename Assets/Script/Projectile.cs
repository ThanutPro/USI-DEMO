using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    public float moveSpeed = 10f;
    public GameObject explosionPrefab;

    AudioManager audioManager;

    // Set a fixed explosion duration in seconds
    public float explosionDuration = 2f;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
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
            // Play sound effect and instantiate explosion
            audioManager.PlaySFX(audioManager.ExplodeEnemy);
            GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);

            // Destroy the enemy and the projectile
            Destroy(collision.gameObject);
            Destroy(gameObject);

            // Destroy the explosion after a fixed duration
            Destroy(explosion, explosionDuration);
        }

        // Check if the projectile collides with the boundary
        if (collision.gameObject.CompareTag("Boundary"))
        {
            Destroy(gameObject);
        }
    }
}

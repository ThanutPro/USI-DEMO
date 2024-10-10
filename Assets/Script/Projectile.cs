using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    public float moveSpeed = 10f;
    public GameObject explosionPrefab;

    AudioManager audioManager;

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
        {;
            // Destroy the enemy and the projectile
            audioManager.PlaySFX(audioManager.ExplodeEnemy);
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(gameObject);
            
        }

        // Check if the projectile collides with the boundary
        if (collision.gameObject.CompareTag("Boundary"))
        {
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    public float moveSpeed = 5;

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
            // Destroy the enemy and the projectile
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}

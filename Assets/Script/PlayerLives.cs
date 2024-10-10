using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLives : MonoBehaviour
{
    public int lives = 3;
    public Image[] livesUI;
    public GameObject explosionPrefab;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start()
    {
        // You could initialize UI or other things here if needed
    }

    // Update is called once per frame
    void Update()
    {
        // Handle any update logic here if necessary
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "Enemy" || collision.collider.gameObject.tag == "Asteroid")
        {
            HandleHit();
            Destroy(collision.collider.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy Projectile" || collision.gameObject.tag == "Asteroid")
        {
            HandleHit();
            Destroy(collision.gameObject);
        }
    }

    private void HandleHit()
    {
        // Play hurt sound
        audioManager.PlaySFX(audioManager.Hurt);

        // Instantiate explosion at the player's position
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);

        // Reduce lives
        lives--;

        // Update the lives UI
        for (int i = 0; i < livesUI.Length; i++)
        {
            livesUI[i].enabled = i < lives;
        }

        // Check if lives are zero or less, destroy player object
        if (lives <= 0)
        {
            Destroy(gameObject);
        }
    }
}

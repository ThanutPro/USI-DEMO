using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float speed = 2f;           // Asteroid speed
    public float changeDirectionInterval = 2f;
    private Vector3 direction;
    private float timer;

    // Screen boundaries
    private float screenTop;
    private float screenBottom;
    private float screenLeft;
    private float screenRight;

    void Start()
    {
        // Set initial direction and timer
        direction = GetRandomDirection();
        timer = changeDirectionInterval;

        // Calculate screen boundaries based on camera
        Camera mainCamera = Camera.main;
        screenTop = mainCamera.orthographicSize;
        screenBottom = -mainCamera.orthographicSize;
        screenRight = screenTop * mainCamera.aspect;
        screenLeft = -screenRight;
    }

    void Update()
    {
        // Move the asteroid
        transform.position += direction * speed * Time.deltaTime;

        // Change direction at intervals
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            direction = GetRandomDirection();
            timer = changeDirectionInterval;
        }

        // Wrap the asteroid when it exits the screen
        ScreenWrap();
    }

    private Vector3 GetRandomDirection()
    {
        float x = Random.Range(-1f, 1f);
        float y = Random.Range(-1f, 1f);
        return new Vector3(x, y).normalized;  // Ensure it's a unit vector
    }

    private void ScreenWrap()
    {
        Vector3 position = transform.position;

        // Wrap the asteroid horizontally
        if (position.x > screenRight)
        {
            position.x = screenLeft;
        }
        else if (position.x < screenLeft)
        {
            position.x = screenRight;
        }

        // Wrap the asteroid vertically
        if (position.y > screenTop)
        {
            position.y = screenBottom;
        }
        else if (position.y < screenBottom)
        {
            position.y = screenTop;
        }

        // Update the position of the asteroid
        transform.position = position;
    }
}

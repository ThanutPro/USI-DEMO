using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    public float moveSpeed = 10;
    public float hInput;
    public float vInput;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Get horizontal and vertical inputs
        hInput = Input.GetAxisRaw("Horizontal");
        vInput = Input.GetAxisRaw("Vertical");

        // Apply horizontal and vertical movement
        transform.Translate(new Vector2(hInput, vInput) * moveSpeed * Time.deltaTime);
    }
}

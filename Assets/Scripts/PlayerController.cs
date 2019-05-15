using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Vector2 movementDirection;
    public float speed;
    public float walkSpeedMultiplier = 1.5f;
    public float runSpeedMultiplier = 3f;
    public bool running = false;
    public Rigidbody2D Rb;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ProcessInputs();
        Move();
    }

    void ProcessInputs()
    {
        movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        speed = Mathf.Clamp(movementDirection.magnitude, 0.0f, 1.0f);
        movementDirection.Normalize();

      running = Input.GetKey(KeyCode.LeftShift);
    }

    void Move() {
        if (running)
        {
            Rb.velocity =  movementDirection * speed * runSpeedMultiplier;
           // Rb.velocity = movementDirection * speed;
        }
        else {
            Rb.velocity = walkSpeedMultiplier * movementDirection * speed;

        }
           
    }

}

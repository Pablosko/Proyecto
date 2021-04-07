using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2d;
    public float aceleration = 8;
    public float speed = 15;
    public float jumpForce = 5;
    public bool grounded;
    public float airAcel = 6;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
      
    }

    void Update()
    {
    int side = 0;

        if (Input.GetKey(KeyCode.D)) 
        {
            side = 1;

        }
        else if (Input.GetKey(KeyCode.A))
        {
            side = -1;
        }

        if(grounded)
            rb2d.AddForce(Vector2.right * side * aceleration);
        else
            rb2d.AddForce(Vector2.right * side * airAcel);

        Vector2 xclamp = new Vector2(rb2d.velocity.x, 0);
        rb2d.velocity = new Vector2(Vector2.ClampMagnitude(xclamp, speed).x, rb2d.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            rb2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }



    }
}

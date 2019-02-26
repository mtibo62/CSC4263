using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    private int jumpCount = 0;
    

    void Start()
    {

    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "ground")
        {
            jumpCount = 0;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey("d"))
        {  
            rb.position = new Vector2(rb.transform.position.x + .2f, rb.transform.position.y);
        }
        if (Input.GetKey("a"))
        {
            rb.position = new Vector2(rb.transform.position.x - .2f, rb.transform.position.y);
        }
        if (Input.GetKeyDown("w") && jumpCount < 2)
        {
            rb.AddForce(new Vector2(0, 8f), ForceMode2D.Impulse);
            jumpCount++;
        }
    }
}

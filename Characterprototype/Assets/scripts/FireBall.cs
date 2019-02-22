using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;
    public GameObject exploson;
    public Vector2 velocity;
    private float timer;

    // Use this for initialization
    void Start()
    {
        Destroy(this.gameObject, 10);
        rb = GetComponent<Rigidbody2D>();
        velocity = rb.velocity;
        timer = 10;

    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.y < velocity.y)
            rb.velocity = velocity;
    }


    void OnCollisionEnter2D(Collision2D col)
    {

        rb.velocity = new Vector2(velocity.x, -velocity.y);


        if (col.collider.tag == "Player")
        {
            Destroy(col.gameObject);
            //Explode();
        }


        if (col.contacts[0].normal.x != 0)
        {
            //Explode();
        }
        if (timer <= 10)
        {
            Destroy(gameObject);
            timer = 10;
        }

    }

    void Explode()
    {
        Instantiate(exploson, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}


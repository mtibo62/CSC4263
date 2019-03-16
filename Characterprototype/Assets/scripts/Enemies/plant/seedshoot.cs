using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seedshoot : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject anima;
    private Rigidbody2D rb;
    public Vector2 velocity;
    private float timer;
    private GameObject anim;


    // Use this for initialization
    void Start()
    {
        Destroy(this.gameObject, 10);
        rb = GetComponent<Rigidbody2D>();
        velocity = rb.velocity;

    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.y < velocity.y)
            rb.velocity = velocity;

        transform.Rotate(0,0, 6f);
    }


    void OnTriggerEnter2D(Collider2D col)
    {

        rb.velocity = new Vector2(velocity.x, -velocity.y);


        if (col.tag == "Player")
        {
            //anim = Instantiate(anima, transform.position, Quaternion.identity) as GameObject;
            Destroy(gameObject);
            //Explode();
        }


        //if (col.contacts[0].normal.x != 0)
        //{
        //    //Explode();
        //}

    }
}


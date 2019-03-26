using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossBullet : MonoBehaviour
{
    // Start is called before the first frame update
    float moveSpeed = 7f;

    Rigidbody2D rb;

    PlayerDamage target;
    Vector2 moveDirection;


    // Use this for initialization
    void Start()
    {
        
        Destroy(this.gameObject, 6f);
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        //if (rb.velocity.y < velocity.y)
        //    rb.velocity = velocity;

        //transform.Rotate(0, 0, 6f);
    }


    void OnTriggerEnter2D(Collider2D col)
    {

        //rb.velocity = new Vector2(velocity.x, -velocity.y);


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

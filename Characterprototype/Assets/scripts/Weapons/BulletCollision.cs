using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    public GameObject anima;
    public GameObject Inventory;
    public Vector2 velocity;

    public int weaponType;
    private GameObject anim;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        velocity = rb.velocity;
    }

    // Update is called once per frame
    public void OnCollisionEnter2D(Collision2D col)
    {
        switch (weaponType)
        {
            case 1:
                break;
            case 2:
                anim = Instantiate(anima, transform.position, Quaternion.identity) as GameObject;
                Destroy(gameObject);
                break;
            case 3:
                anim = Instantiate(anima, transform.position, Quaternion.identity) as GameObject;
                Destroy(gameObject);
                break;
            case 4:
                rb.velocity = new Vector2(velocity.x, -velocity.y);
                if (col.gameObject.tag == "enemy" || col.gameObject.tag == "boss" )
                {
                    anim = Instantiate(anima, transform.position, Quaternion.identity) as GameObject;
                    Destroy(gameObject);
                }
                break;
            case 5:
                anim = Instantiate(anima, transform.position, Quaternion.identity) as GameObject;
                Destroy(gameObject);
                break;

            case 15://boss weapon
                anim = Instantiate(anima, transform.position, Quaternion.identity) as GameObject;
                Destroy(gameObject);
                break;
            default:
                Destroy(gameObject);
                break;
        }
    }
}

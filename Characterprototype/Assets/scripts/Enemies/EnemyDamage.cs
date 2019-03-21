using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public Sprite[] sprites;
    public GameObject healthBar;
    public GameObject gm;
    public int health = 8;

    private SpriteRenderer sr;
    private int scored;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager");
        //sr = healthBar.GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        scored = 0;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "projectile")
        {
            Debug.Log("Hit");
            health--;
        }
        if (col.gameObject.tag == "iceshot")
            health -= 5;

    }
    // Update is called once per frame
    void Update()
    {


        //if (health <= 6)
        //    sr.sprite = sprites[0];
        //if (health <= 4)
        //    sr.sprite = sprites[1];
        //if (health <= 2)
        //    sr.sprite = sprites[2];
        if (health <= 0)
        {
            if (scored == 0)
                gm.GetComponent<GameManager>().score += 25;
            scored++;
            //sr.sprite = sprites[3];
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            rb.AddForce(new Vector2(0, 5));
        }
        //if (gameObject.transform.position.y < -8)
        //    Destroy(gameObject);

    }

}

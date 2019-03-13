using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDamage : MonoBehaviour
{
    public Sprite[] sprites;
    public GameObject healthBar;
    public GameObject gm;
    public int health = 20;

    private SpriteRenderer sr;
    private int scored;

    System.Random rand = new System.Random();

    // Start is called before the first frame update
    void Start()
    {
        sr = healthBar.GetComponent<SpriteRenderer>();
        scored = 0;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "projectile")
        {
            health--;
        }

    }
    // Update is called once per frame
    void Update()
    {
        if (health <= 16)
            sr.sprite = sprites[0];
        if (health <= 12)
            sr.sprite = sprites[1];
        if (health <= 8)
            sr.sprite = sprites[2];
        if(health <= 4)
            sr.sprite = sprites[3];
        if (health <= 0)
        {
            if (scored == 0)
                gm.GetComponent<GameManager>().score += 100;
            scored++;
            sr.sprite = sprites[4];
            gameObject.AddComponent<Rigidbody2D>();
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
        }
        if (gameObject.transform.position.y < -8)
            Destroy(gameObject);

    }
}

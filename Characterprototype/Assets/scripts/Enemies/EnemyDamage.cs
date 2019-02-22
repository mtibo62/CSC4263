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
        if (health <= 6)
            sr.sprite = sprites[0];
        if (health <= 4)
            sr.sprite = sprites[1];
        if (health <= 2)
            sr.sprite = sprites[2];
        if (health <= 0)
        {
            if (scored == 0)
                gm.GetComponent<GameManager>().score += 25;
            scored++;
            sr.sprite = sprites[3];
            gameObject.GetComponent<BoxCollider2D>().enabled = false;           
        }
        if (gameObject.transform.position.y < -8)
            Destroy(gameObject);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDamage : MonoBehaviour
{
    public Sprite[] sprites;
    public GameObject healthBar;
    public GameObject[] bodyParts;
    public Text healthText;
    public int health = 10;

    System.Random rand = new System.Random();

    private SpriteRenderer sr;



    // Start is called before the first frame update
    void Start()
    {
        sr = healthBar.GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "enemy" || col.gameObject.tag == "BossBullet")
        {
            health--;
        }

    }
    // Update is called once per frame
    void Update()
    {
        healthText.text = health.ToString();
        if (health == 10)
        {
            sr.enabled = false;
            healthText.color = new Color(73, 172, 50);
        }
        if (health <= 9)
        {
            sr.sprite = sprites[0];
            sr.enabled = true;
        }
        if (health <= 8)
            sr.sprite = sprites[1];
        if (health <= 7)
            sr.sprite = sprites[1];
        if (health <= 6)
        {
            sr.sprite = sprites[2];
            healthText.color = new Color(255, 255, 102);
        }
        if (health <= 5)
            sr.sprite = sprites[3];
        if (health <= 4)
            sr.sprite = sprites[4];
        if (health <= 3)
            sr.sprite = sprites[5];
        healthText.color = new Color(255, 76, 76);
        if (health <= 2)
            sr.sprite = sprites[6];
        if (health <= 0)
        {
            sr.sprite = sprites[7];
            transform.DetachChildren();
            Destroy(gameObject);
            Explode();
        }
    }
    private void Explode()
    {
        for (int i = 0; i < bodyParts.Length; i++)
        {
            bodyParts[i].AddComponent<BoxCollider2D>();
            bodyParts[i].AddComponent<Rigidbody2D>();
        }


        Rigidbody2D rb0 = bodyParts[0].GetComponent<Rigidbody2D>();
        Rigidbody2D rb1 = bodyParts[1].GetComponent<Rigidbody2D>();
        Rigidbody2D rb3 = bodyParts[3].GetComponent<Rigidbody2D>();
        Rigidbody2D rb4 = bodyParts[4].GetComponent<Rigidbody2D>();

 
        rb0.AddForce(new Vector2((float)rand.NextDouble() * 10, (float)rand.NextDouble() * 5));
        rb1.AddForce(new Vector2((float)rand.NextDouble() * 10, (float)rand.NextDouble() * 5));
        rb3.AddForce(new Vector2((float)rand.NextDouble() * 10, (float)rand.NextDouble() * 5));
        rb4.AddForce(new Vector2((float)rand.NextDouble() * 10, (float)rand.NextDouble() * 5)); 
    }
}

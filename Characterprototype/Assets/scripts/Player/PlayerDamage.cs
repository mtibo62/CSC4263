using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerDamage : MonoBehaviour, IDamageable
{
    public GameObject gm;
    public Sprite[] sprites;
    public GameObject[] bodyParts;
    public GameObject damage;
    public Text healthText;
    public int health = 10;

    System.Random rand = new System.Random();

    private SpriteRenderer sr;
    public bool canTakeDamage;
    private float coolDown;


    // Start is called before the first frame update
    void Start()
    {
      
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if ((col.gameObject.tag == "enemy" || col.gameObject.tag == "BossBullet") && canTakeDamage)
        {
            canTakeDamage = false;
            coolDown = 2;
            GameObject lighting = Instantiate(damage, transform.position, Quaternion.identity) as GameObject;
            lighting.transform.parent = transform;
            health--;
        }

    }

    public void TakeDamage(int damageTaken)
    {
        if (canTakeDamage)
        {
            canTakeDamage = false;
            coolDown = 2;
            health = health - damageTaken;
            GameObject lighting = Instantiate(damage, transform.position, Quaternion.identity) as GameObject;
            lighting.transform.parent = transform;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (coolDown >= 0)
            coolDown -= Time.deltaTime;
        if (coolDown <= 0)
            canTakeDamage = true;

        healthText.text = health.ToString();
      
        if (health <= 0)
        {
            transform.DetachChildren();
            Explode();
            Destroy(gameObject);
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

 
        rb0.velocity = new Vector2(-4f, 10f);
        rb1.velocity = new Vector2(6f, 8f);
        rb3.velocity = new Vector2(-8f, 4f);
        rb4.velocity = new Vector2(7f, 9f);
        //save the score and current level.
        PlayerPrefs.SetFloat("Score", gm.GetComponent<GameManager>().score);
        PlayerPrefs.SetString("Level", SceneManager.GetActiveScene().name);
        PlayerPrefs.Save();
        gm.GetComponent<GameManager>().isAlive = false;
    }
}

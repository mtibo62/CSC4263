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
    public int health;

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
            Die();
        }
    }
    private void Die()
    {
        PlayerPrefs.SetFloat("Score", gm.GetComponent<GameManager>().score);
        PlayerPrefs.SetString("Level", SceneManager.GetActiveScene().name);
        PlayerPrefs.Save();
        gm.GetComponent<GameManager>().isAlive = false;
    }
}

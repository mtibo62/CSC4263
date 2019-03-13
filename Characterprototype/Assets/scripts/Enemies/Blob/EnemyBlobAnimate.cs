using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBlobAnimate : MonoBehaviour
{
    public GameObject gm;
    public Sprite[] sprites;
    public Sprite[] death;
    public float FPS;
    public float deathFPS;
    private SpriteRenderer sr;
    private int health;
    private int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        health = gameObject.GetComponent<EnemyDamage>().health;
        
        int index = (int)(Time.timeSinceLevelLoad * FPS);
        index = index % sprites.Length;
        sr.sprite = sprites[index];
             
    }
}

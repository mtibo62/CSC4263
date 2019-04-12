using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobMove :  EnemyMove
{

    [HideInInspector]
    public Rigidbody2D rb;

    public int moveSpeed;
    public bool triggered;

    public AudioSource soundFx;
    public AudioClip enemyFx;


    // Start is called before the first frame update
    void Start()
    {
        triggered = false;
        rb = GetComponent<Rigidbody2D>();
        soundFx = GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            soundFx.clip = enemyFx;
            soundFx.Play();
            Vector2 dir = target.transform.position - rb.transform.position;

            if (GetComponent<EnemyDamage>().health > 0)
                rb.transform.position += (target.transform.position - rb.transform.position).normalized * moveSpeed * Time.deltaTime;
        }
    }
}

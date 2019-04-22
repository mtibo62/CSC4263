using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusterCannonMissle : MonoBehaviour
{
    public float speed;

    private Transform player;
    private Vector2 target;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        target = new Vector2(player.position.x, player.position.y);

    }
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

        if (transform.position.x  == target.x && transform.position.y == target.y)
        {
            DestroyBusterCannonMissle();
        }


        void OnTriggerEnter2D(Collider2D other){
            if (other.CompareTag("Player"))
            {
                DestroyBusterCannonMissle();
            }

        }
    }
    void DestroyBusterCannonMissle()
    {
        Destroy(gameObject);
    }
}

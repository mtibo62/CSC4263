using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameMove : MonoBehaviour
{
    public GameObject player;
    private Vector2 moveDir;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<flameShoot>().triggered && GetComponent<EnemyDamage>().health > 0)
        {
            moveDir = transform.position - player.transform.position;
            rb.velocity = moveDir/2.5f;
        }
    }
}

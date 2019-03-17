using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilFlowerAttack : EnemyMove
{
    [HideInInspector]
    public Rigidbody2D rb;

    public int moveSpeed;
   

    public float localScaleSetNum;

    // Start is called before the first frame update
    void Start()
    {
        localScaleSetNum = transform.localScale.x;
        
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Attack();
    }

    public void Attack()
    {

    }


    public void Move()
    {
        if (target.transform.position.x > rb.transform.localScale.x)
        {
            transform.localScale = new Vector3(-localScaleSetNum, transform.localScale.y, 0);
        }
        else
        {
            transform.localScale = new Vector3(localScaleSetNum, transform.localScale.y, 0);
        }
    }
}

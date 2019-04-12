using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : EnemyMove
{

    public Rigidbody2D rb;

    public int moveSpeed;
    public bool triggered;

    public GameObject[] shooters;

    private float localScaleSetNum;
    private float leftBound;
    private float rightBound;

    void Flyer_Move()
    {
        if (target != null)
        {
            Vector2 dir = target.transform.position - rb.transform.position;

            //if (GetComponent<EnemyDamage>().health > 0)
                //rb.transform.position += (target.transform.position - rb.transform.position).normalized * moveSpeed * Time.deltaTime;

            if (target.transform.position.x > rb.transform.position.x)
            {
                transform.localScale = new Vector3(-localScaleSetNum, transform.localScale.y, 0);
                rb.velocity = new Vector3(3, 0, 0);
            }
            else
            {
                transform.localScale = new Vector3(localScaleSetNum, transform.localScale.y, 0);
                rb.velocity = new Vector3(-3, 0, 0);
            }

            rb.transform.rotation = Quaternion.Euler(new Vector3(0,0, -90));
        }
    }


  
    // Start is called before the first frame update
    void Start()
    {
        localScaleSetNum = transform.localScale.x;
        leftBound = localScaleSetNum - 13;
        rightBound = localScaleSetNum + 13;
        triggered = false;
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Flyer_Move();
    }
}

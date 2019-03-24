using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YetiMove : EnemyMove
{

    public Animator anim;
    private SpriteRenderer sr;

    [HideInInspector]
    public Rigidbody2D rb;

    public int moveSpeed;

    public float localScaleSetNum;

    // Start is called before the first frame update
    void Start()
    {
        localScaleSetNum = transform.localScale.x;
        
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (target != null)
        {
            Move();
            if (!anim.GetBool("IsWalking"))
            {
                anim.SetBool("IsWalking", true);
            }
        }
        else
        {
            if (anim.GetBool("IsWalking"))
            {
                anim.SetBool("IsWalking", false);
            }
        }
    }

    // Update is called once per frame
    void Move()
    {
        if (target != null)
        {
            float xdir = target.transform.position.x - rb.transform.position.x;
            float ydir = target.transform.position.y - rb.transform.position.y;

            if (GetComponent<EnemyDamage>().health > 0 && !anim.GetBool("IsPunching"))
            {
                if (xdir > 2.2 || xdir < -4)
                {
                    rb.transform.position += (target.transform.position - rb.transform.position).normalized * moveSpeed * Time.deltaTime;
                }
                else
                {
                    anim.SetBool("IsPunching", true);
                    Debug.Log("Check");
                    StartCoroutine(GetComponent<YetiAttack>().Attack());
                    
                }
            }
                

            if (target.transform.position.x > rb.transform.position.x)
            {
                transform.localScale = new Vector3(-localScaleSetNum, transform.localScale.y, 0);
            }
            else
            {
                transform.localScale = new Vector3(localScaleSetNum, transform.localScale.y, 0);
            }

        }
    }
}

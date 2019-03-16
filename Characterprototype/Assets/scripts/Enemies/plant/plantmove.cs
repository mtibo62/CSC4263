using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plantmove : EnemyMove
{

    public Animator anim;
    private SpriteRenderer sr;

    [HideInInspector]
    public Rigidbody2D rb;

    public int moveSpeed;
    public bool triggered;

    private float localScaleSetNum;

    // Start is called before the first frame update
    void Start()
    {
        localScaleSetNum = transform.localScale.x;
        triggered = false;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (target != null)
        {
            Walk();
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
    void Walk()
    {
        if (target != null)
        {
            Vector2 dir = target.transform.position - rb.transform.position;

            if (GetComponent<EnemyDamage>().health > 0)
                rb.transform.position += (target.transform.position - rb.transform.position).normalized * moveSpeed * Time.deltaTime;

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

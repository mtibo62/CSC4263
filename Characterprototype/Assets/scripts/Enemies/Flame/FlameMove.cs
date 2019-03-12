using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;

public class FlameMove : MonoBehaviour, ISetTarget
{
    public GameObject player;
    public Animator anim;
    private SpriteRenderer sr;

    private float moveDir;
    private Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    public void setTarget(GameObject target)
    {
        player = target;
        Debug.Log("set in Move");
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
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

        AnimController();
    }

    void Walk()
    {
        if (GetComponent<EnemyDamage>().health > 0)
        {
            //anim.SetBool("IsWalking", true);
            Vector2 dir = player.transform.position - rb.transform.position;


            rb.transform.position += (player.transform.position - rb.transform.position).normalized * 3 * Time.deltaTime;

            if (player.transform.position.x > rb.transform.position.x)
            {
                sr.flipX = true;
            }
            else
            {
                sr.flipX = false;
            }
        }
        else
        {
            //anim.SetBool("IsWalking", false);
        }
    }

    void AnimController()
    {
        if (anim.GetBool("IsWalking"))
        {

        }
    }
}

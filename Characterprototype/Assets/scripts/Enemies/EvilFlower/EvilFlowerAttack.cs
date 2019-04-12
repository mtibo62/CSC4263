using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilFlowerAttack : EnemyMove
{
    [HideInInspector]
    public Rigidbody2D rb;
   
    public float localScaleSetNum;

    public Animator anim;

    public GameObject hitBox;

    bool isAttacking;

    public AudioSource soundFx;
    public AudioClip enemyFx;

    // Start is called before the first frame update
    void Start()
    {
        localScaleSetNum = transform.localScale.x;
        hitBox.GetComponent<BoxCollider2D>().enabled = false;
        rb = GetComponent<Rigidbody2D>();
        soundFx = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            Follow();
            AttackCheck();
        }


    }

    public void AttackCheck()
    {
        float xdir = target.transform.position.x - rb.transform.position.x;
        float ydir = target.transform.position.y - rb.transform.position.y;

        if ((xdir > .5 || xdir < -1) && isAttacking == false)
        {
            anim.SetBool("IsAttacking", true);
            Debug.Log("Check");
            StartCoroutine(Attack());
            isAttacking = true;
        }
        else
        {

        }
    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(1f);
        hitBox.GetComponent<BoxCollider2D>().enabled = true;
        soundFx.clip = enemyFx;
        soundFx.Play();
        Debug.Log("Attack");
        yield return new WaitForSeconds(.2f);
        hitBox.GetComponent<BoxCollider2D>().enabled = false;
        isAttacking = false;
        anim.SetBool("IsAttacking", false);
    }

    public void Follow()
    {
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

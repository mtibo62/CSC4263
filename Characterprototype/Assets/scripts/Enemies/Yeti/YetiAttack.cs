using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YetiAttack : MonoBehaviour
{
    public Animator anim;

    public GameObject hitBox;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator Attack()
    {
        yield return new WaitForSeconds(1);
        hitBox.GetComponent<BoxCollider2D>().enabled = true;

        Debug.Log("Attack");
        yield return new WaitForSeconds(1);
        hitBox.GetComponent<BoxCollider2D>().enabled = false;
        anim.SetBool("IsPunching", false);
    }
}

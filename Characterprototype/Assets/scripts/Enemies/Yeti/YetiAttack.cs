using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YetiAttack : MonoBehaviour
{

    public GameObject hitBox;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator Attack()
    {
        hitBox.GetComponent<BoxCollider2D>().enabled = true;
        Debug.Log("Attack");
        yield return new WaitForSeconds(2);
        hitBox.GetComponent<BoxCollider2D>().enabled = false;
    }
}

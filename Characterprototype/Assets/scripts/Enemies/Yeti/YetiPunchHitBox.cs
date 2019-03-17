using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YetiPunchHitBox : MonoBehaviour
{

    
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Coll");
        IDamageable obj = col.gameObject.GetComponent<IDamageable>();
        if (obj != null)
        {
            obj.TakeDamage(2);
            GetComponent<BoxCollider2D>().enabled = false;
            Debug.Log("Punch");
        }
    }
}

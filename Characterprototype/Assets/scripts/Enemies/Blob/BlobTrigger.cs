using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobTrigger : MonoBehaviour
{
    public GameObject blob;
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player") { }
            blob.GetComponent<BlobMove>().triggered = true;
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player") { }
            blob.GetComponent<BlobMove>().triggered = false;
    }
   

}

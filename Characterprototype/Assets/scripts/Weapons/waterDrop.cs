using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterDrop : MonoBehaviour
{
    private BoxCollider2D bc;
    // Start is called before the first frame update
    void Start()
    {

        bc = GetComponent<BoxCollider2D>();
        StartCoroutine(timer());
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "plant")
        {
            Debug.Log("hit");
            Destroy(gameObject);
        }
    }

    IEnumerator timer()
    {
        yield return new WaitForSeconds(.5f);
        Destroy(gameObject);
    }
}

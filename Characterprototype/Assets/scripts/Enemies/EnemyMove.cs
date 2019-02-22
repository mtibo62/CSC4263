using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{

    public GameObject target;
    public Rigidbody2D rb;
    public int moveSpeed;
    public bool triggered;

    // Start is called before the first frame update
    void Start()
    {
        triggered = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 dir = target.transform.position - rb.transform.position;

        if (triggered)
            rb.transform.position += (target.transform.position - rb.transform.position).normalized * moveSpeed * Time.deltaTime;
    }
}

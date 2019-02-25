using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthApple : MonoBehaviour
{
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-2f, 2f);
    }

    private void Update()
    {
        
    }

}

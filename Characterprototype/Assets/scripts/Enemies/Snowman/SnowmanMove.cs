using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowmanMove : EnemyMove {
    // Start is called before the first frame update
    float localScaleSetNum;

    [HideInInspector]
    public Rigidbody2D rb;

    void Start()
    {
        localScaleSetNum = transform.localScale.x;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target.transform.position.x > rb.transform.position.x)
        {
            transform.localScale = new Vector3(localScaleSetNum, transform.localScale.y, 0);
        }
        else
        {
            transform.localScale = new Vector3(-localScaleSetNum, transform.localScale.y, 0);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameMove : MonoBehaviour, ISetTarget
{
    public GameObject player;
    private float moveDir;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void setTarget(GameObject target)
    {
        player = target;
        Debug.Log("set in Move");
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<EnemyDamage>().health > 0 && player != null) { 
        Vector2 dir = player.transform.position - rb.transform.position;


        rb.transform.position += (player.transform.position - rb.transform.position).normalized * 3 * Time.deltaTime;
    }
    }
}

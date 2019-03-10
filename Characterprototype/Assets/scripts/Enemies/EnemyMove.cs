using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour, ISetTarget
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

    public void setTarget(GameObject targetPlayer)
    {
        target = targetPlayer;
        Debug.Log("Set in shoot");
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            Vector2 dir = target.transform.position - rb.transform.position;

            if (GetComponent<EnemyDamage>().health > 0)
                rb.transform.position += (target.transform.position - rb.transform.position).normalized * moveSpeed * Time.deltaTime;
        }
    }
}

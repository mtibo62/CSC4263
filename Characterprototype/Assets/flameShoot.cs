using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flameShoot : MonoBehaviour
{
    public GameObject projectile;
    public GameObject target;
    public Vector2 velocity;
    public float canShoot;
    public Vector2 offset = new Vector2(0.4f, 0.1f);
    public bool triggered;

    private Vector2 TargetPos;


    // Use this for initialization
    void Start()
    {
        triggered = true;
    }

    // Update is called once per frame
    void Update()
    {
        TargetPos = target.transform.position;
        canShoot -= Time.deltaTime;

        if (canShoot == 0)
        {
            GameObject go = (GameObject)Instantiate(projectile, (Vector2)transform.position + offset * transform.localScale.x, Quaternion.identity);
            go.transform.LookAt(TargetPos);
            go.GetComponent<Rigidbody2D>().velocity = new Vector2(velocity.x * transform.localScale.x, velocity.y);
            canShoot = 3;
        }


    }

}


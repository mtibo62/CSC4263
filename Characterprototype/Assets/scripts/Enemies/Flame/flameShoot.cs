
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class flameShoot : MonoBehaviour, ISetTarget
{
    public GameObject projectile;
    public GameObject target;
    public GameObject obj;//the object attached
    public Vector2 velocity;
    public float canShoot;
    public Vector2 offset = new Vector2(0.4f, 0.1f);
    public bool triggered;

    private Rigidbody2D rb;

    private Vector2 ObjPos; //position of your object
    private Vector2 targetPos; //position of the mouse pointer
    private Vector2 RelPos; //position of pointer relative to object

    private float angle; //degrees 
  


    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        canShoot = 0;
        
    }

    public void setTarget(GameObject targetPlayer)
    {
        target = targetPlayer;
        Debug.Log("Set in shoot");
    }
    
    void Update()
    {
        if(target != null)
        {
            Shoot();
        }
    }

    // Update is called once per frame
    void Shoot()
    {
            ObjPos = obj.transform.position;
            targetPos = target.transform.position;
            RelPos = targetPos - ObjPos;

            angle = Mathf.Atan2(RelPos.x, RelPos.y);

            angle = angle * Mathf.Rad2Deg;
            canShoot -= Time.deltaTime;

            if (canShoot <= 0)
            {
                if (direction(angle) == 1)
                {
                    //sr.flipX = false;
                    GameObject go = Instantiate(projectile, (Vector2)transform.position + offset * transform.localScale.x, Quaternion.identity);
                    go.GetComponent<Rigidbody2D>().velocity = new Vector2(velocity.x * transform.localScale.x, velocity.y);
                    canShoot = 4;
                }
                else
                {
                    //sr.flipX = true;
                    GameObject go = Instantiate(projectile, (Vector2)transform.position + offset * transform.localScale.x, Quaternion.identity);
                    go.GetComponent<Rigidbody2D>().velocity = new Vector2(-1 * (velocity.x * transform.localScale.x), velocity.y);
                    canShoot = 4;
                }
            }

        
    }
    private int direction(float a)
    {
        if (a >= -179.99f && a < 0)
            return 1;
        else
            return 0;
    }

}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plantshoot : MonoBehaviour, ISetTarget
{
    public GameObject projectile;
    public GameObject target;
    public GameObject obj;//the object attached
    public GameObject shooterOpening;
    public Vector2 velocity;
    public float canShoot;
    public Vector2 offset = new Vector2(0.4f, 0.1f);

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
        if (target != null)
        {
            Shoot();
        }
    }

    // Update is called once per frame
    void Shoot()
    {
        ObjPos = transform.position;
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
                GameObject go = Instantiate(projectile, shooterOpening.transform.position, Quaternion.identity);
                go.GetComponent<Rigidbody2D>().velocity = new Vector2(velocity.x * transform.localScale.x, velocity.y);
                canShoot = 2.5f;
            }
            else
            {
                //sr.flipX = true;
                GameObject go = Instantiate(projectile, /*(Vector2)transform.position + offset * transform.localScale.x*/ shooterOpening.transform.position, Quaternion.identity);
                go.GetComponent<Rigidbody2D>().velocity = new Vector2(velocity.x * transform.localScale.x, velocity.y);
                //velocity here is positive because the local scale of the entire plant enemy is being swapped to negative when the player moves on the right side.
                //see plantmove.cs line 36
                canShoot = 2.5f;
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

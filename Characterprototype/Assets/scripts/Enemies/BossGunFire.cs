using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGunFire : MonoBehaviour, ISetTarget
{
    public float timeToFire;
    public GameObject projectile;
    public GameObject obj;
    public GameObject Player;
    public GameObject trigger;
    public GameObject target;


    private Vector2 ObjPos; //position of your object
    private Vector2 PlayerPos; //position of the mouse pointer
    private Vector2 RelPos; //position of pointer relative to object

    private float angle; //degrees 
    private float time;
    private bool triggered;

    // Start is called before the first frame update
    void Start()
    {
        time = timeToFire;
        triggered = false;
    }

    public void setTarget(GameObject targetPlayer)
    {
        Player = targetPlayer;
        Debug.Log("Set in shoot");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Player != null)
        {
            ObjPos = obj.transform.position;
            PlayerPos = Player.transform.position;
            RelPos = PlayerPos - ObjPos;

            angle = Mathf.Atan2(RelPos.x, RelPos.y);

            angle = angle * Mathf.Rad2Deg;
            timeToFire = timeToFire - Time.deltaTime;
            //triggered = trigger.GetComponent<BossTrigger>().fight;
            if (canFire(angle) != 0 && /*triggered &&*/ gameObject.GetComponent<BoxCollider2D>().enabled)
            {
                if (timeToFire <= 0)
                {
                    GameObject proj = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
                    timeToFire = time;
                }
            }
        }
    }
    private int canFire(float a)
    {
        if (a <= -30 && a > -40)//look up left
            return 1;
        if (a <= -40 && a > -50)
            return 2;
        if (a <= -50 && a > -60)
            return 3;
        if (a <= -60 && a > -70)
            return 4;
        if (a <= -70 && a > -80)
            return 5;
        if (a <= -80 && a > -90)//look straight left
            return 6;
        if (a <= -90 && a > -100)//look down left
            return 7;
        else
            return 0;
    }
}

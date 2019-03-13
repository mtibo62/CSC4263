using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTrigger : MonoBehaviour
{

    public bool fight;
    void Start()
    {
        fight = false;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            //enemy.GetComponent<flameShoot>().triggered = true;
             Component[] setTarget = gameObject.GetComponentsInChildren(typeof(ISetTarget));

            foreach ( ISetTarget target in setTarget)
            {
                target.setTarget(col.gameObject);
            }
            //GetComponent<FlameMove>().player = col.gameObject;
            //target = col.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            //enemy.GetComponent<flameShoot>().triggered = false;
            Component[] setTarget = gameObject.GetComponentsInChildren(typeof(ISetTarget));

            foreach (ISetTarget target in setTarget)
            {
                target.setTarget(null);
            }
            //target = null;
        }
    }

}

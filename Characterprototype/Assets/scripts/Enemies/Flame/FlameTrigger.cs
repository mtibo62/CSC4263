using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameTrigger : MonoBehaviour
{
    public static GameObject target;
    public GameObject enemy;
    void Start()
    {

    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            //enemy.GetComponent<flameShoot>().triggered = true;
            //gameObject.GetComponentInParent<ISetTarget>().setTarget(col.gameObject);

            Component[] setTarget = gameObject.GetComponentsInParent(typeof(ISetTarget));

            foreach (ISetTarget target in setTarget)
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
            //gameObject.GetComponentInParent<ISetTarget>().setTarget(null);
            Component[] setTarget = gameObject.GetComponentsInParent(typeof(ISetTarget));

            foreach (ISetTarget target in setTarget)
            {
                target.setTarget(null);
            }

            //target = null;
        }
    }
}

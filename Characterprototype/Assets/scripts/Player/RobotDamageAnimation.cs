using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotDamageAnimation : MonoBehaviour
{
   
    public float coolDown;

    // Update is called once per frame
    void Update()
    {
        coolDown -= Time.deltaTime;
        if (coolDown <= 0)
        {
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeTimer : MonoBehaviour
{
    public float timer;
    public GameObject anima;
    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            GameObject anim = Instantiate(anima, transform.position, Quaternion.identity) as GameObject;
            Destroy(gameObject);
        }
        
    }
}

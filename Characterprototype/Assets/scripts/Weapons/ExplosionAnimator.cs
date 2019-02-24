using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionAnimator : MonoBehaviour
{



    void Start()
    {
        
    }
    private void Update()
    {
        Destroy(gameObject, .35f);
    }

}

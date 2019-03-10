using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class FlameAnimCont : MonoBehaviour
{
    public Animator anim;
    public bool animWalkTrigger;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(animWalkTrigger)
        {
           // anim.SetBool(IsWalking, true);
        }
        else
        {
           // anim.SetBool(IsWalking, false);
        }
    }
}

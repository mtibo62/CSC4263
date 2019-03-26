using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<< HEAD
=======

>>>>>>> a6912dc9c0f5c80bf94da0d576b02eda83f4bf89

public class EnemyMove : MonoBehaviour, ISetTarget
{
    
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void setTarget(GameObject targetPlayer)
    {
        target = targetPlayer;
        Debug.Log("Set in move");
    }


}

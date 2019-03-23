using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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

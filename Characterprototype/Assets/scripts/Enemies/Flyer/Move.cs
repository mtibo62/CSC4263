using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Move : MonoBehaviour { 

    public float speed;
    public float distance;

    private bool movingRight = true;

    public Transform skyDetection;

    private void Update() 
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D skyInfo = Physics2D.Raycast(skyDetection.position, Vector2.down, distance);
        if(skyInfo.collider == false)
        {
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            } else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }

        }
    }
}

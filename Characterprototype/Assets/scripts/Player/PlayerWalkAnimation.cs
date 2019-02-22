using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerWalkAnimation : MonoBehaviour
{
    public Sprite[] left; //sprites to animate
    public GameObject obj;

    private SpriteRenderer sr;

    private Vector2 ObjPos; //position of your object
    private Vector2 MousePos; //position of the mouse pointer
    private Vector2 RelPos; //position of pointer relative to object

    private float angle; //degrees 
    public float FPS;


    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ObjPos = obj.transform.position;
        MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RelPos = MousePos - ObjPos;

        angle = Mathf.Atan2(RelPos.x, RelPos.y);

        angle = angle * Mathf.Rad2Deg;

        int index = (int)(Time.timeSinceLevelLoad * FPS);
        switch (direction(angle))
        {
            case 1:
                sr.flipX = true;
                if (Input.GetKey("a") || Input.GetKey("d"))
                {
                    index = index % left.Length;
                    sr.sprite = left[index];
                }
                else
                    sr.sprite = left[0];
                break;
            default:
                sr.flipX = false;
                if (Input.GetKey("a") || Input.GetKey("d"))
                {
                    index = index % left.Length;
                    sr.sprite = left[index];
                }
                else
                    sr.sprite = left[0];
                break;
        }

    }
    private int direction(float a)
    {
        if (a >= -179.99f && a < 0)
            return 1;
        else
            return 0;
    }
}


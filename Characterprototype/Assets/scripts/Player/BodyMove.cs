using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyMove : MonoBehaviour
{
    public Sprite[] sprites; //sprites to animate
    public GameObject obj;

    private SpriteRenderer sr;

    private Vector2 ObjPos; //position of your object
    private Vector2 MousePos; //position of the mouse pointer
    private Vector2 RelPos; //position of pointer relative to object

    private float angle; //degrees 

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

        switch (Direction(angle))
        {
            case 1:
                sr.flipX = false;
                sr.sprite = sprites[1];
                break;
            case 2:
                sr.flipX = false;
                sr.sprite = sprites[2];
                break;
            case 3:
                sr.flipX = false;
                sr.sprite = sprites[3];
                break;
            case 4:
                sr.flipX = true;
                sr.sprite = sprites[3];
                break;
            case 5:
                sr.flipX = true;
                sr.sprite = sprites[2];
                break;
            case 6:
                sr.flipX = true;
                sr.sprite = sprites[1];
                break;
            case 7:
                sr.flipX = true;
                sr.sprite = sprites[1];
                break;
            case 8:
                sr.flipX = true;
                sr.sprite = sprites[2];
                break;
            case 9:
                sr.flipX = true;
                sr.sprite = sprites[3];
                break;
            case 10:
                sr.flipX = false;
                sr.sprite = sprites[3];
                break;
            case 11:
                sr.flipX = false;
                sr.sprite = sprites[2];
                break;
            case 12:
                sr.flipX = false;
                sr.sprite = sprites[1];
                break;
            case 13:
                sr.flipX = true;
                sr.sprite = sprites[0];
                break;
            default:
                sr.flipX = false;
                sr.sprite = sprites[0];
                break;
        }
    }
    private int Direction(float a)
    {
        if (a <= 30 && a > 20)//swing up
            return 1;
        if (a <= 20 && a > 10)
            return 2;
        if (a <= 10 && a > 0)
            return 3;
        if (a <= 0 && a > -10)
            return 4;
        if (a <= -10 && a > -20)
            return 5;
        if (a <= -20 && a > -30)
            return 6;
        if (a <= -110 && a > -130)//swing down around
            return 7;
        if (a <= -130 && a > -140)
            return 8;
        if (a <= -140 && a > -150)
            return 9;
        if (a <= -150 && a > -170)
            return 10;
        if (a <= -170 && a < 170)//swing down
            return 11;
        if (a <= 170 && a > 150)
            return 12;
        if (a <= -30 && a > -110)
            return 13;
        else
            return 0;
    }

}

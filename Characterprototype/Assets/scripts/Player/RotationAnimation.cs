using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotationAnimation : MonoBehaviour
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

        switch (LookAround(angle))
        {
            case 1:
                sr.flipX = false;
                sr.sprite = sprites[1];//look up
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
                sr.flipX = false;
                sr.sprite = sprites[4];
                break;
            case 5:
                sr.flipX = false;
                sr.sprite = sprites[5];
                break;
            case 6:
                sr.flipX = false;
                sr.sprite = sprites[11];//swing around
                break;
            case 7:
                sr.flipX = false;
                sr.sprite = sprites[12];
                break;
            case 8:
                sr.flipX = false;
                sr.sprite = sprites[13];
                break;
            case 9:
                sr.flipX = true;
                sr.sprite = sprites[13];
                break;
            case 10:
                sr.flipX = true;
                sr.sprite = sprites[12];
                break;
            case 11:
                sr.flipX = true;
                sr.sprite = sprites[11];
                break;
            case 12:
                sr.flipX = true;
                sr.sprite = sprites[5];
                break;
            case 13:
                sr.flipX = true;
                sr.sprite = sprites[4];
                break;
            case 14:
                sr.flipX = true;
                sr.sprite = sprites[3];
                break;
            case 15:
                sr.flipX = true;
                sr.sprite = sprites[2];
                break;
            case 16:
                sr.flipX = true;
                sr.sprite = sprites[1];
                break;
            case 17:
                sr.flipX = true;
                sr.sprite = sprites[0];
                break;
            case 18:
                sr.flipX = true;
                sr.sprite = sprites[7];//look down left
                break;
            case 19:
                sr.flipX = true;
                sr.sprite = sprites[6];
                break;
            case 20:
                sr.flipX = true;
                sr.sprite = sprites[8];
                break;
            case 21:
                sr.flipX = true;
                sr.sprite = sprites[9];//swing down around
                break;
            case 22:
                sr.flipX = true;
                sr.sprite = sprites[10];
                break;
            case 23:
                sr.flipX = false;
                sr.sprite = sprites[10];
                break;
            case 24:
                sr.flipX = false;
                sr.sprite = sprites[10];
                break;
            case 25:
                sr.flipX = false;
                sr.sprite = sprites[8];
                break;
            case 26:
                sr.flipX = false;
                sr.sprite = sprites[7];
                break;
            case 27:
                sr.flipX = false;
                sr.sprite = sprites[6];
                break;
            case 28:
                sr.flipX = false;
                sr.sprite = sprites[0];
                break;
            default:
                sr.flipX = false;
                sr.sprite = sprites[0];
                break;
        }
        
        
    }
    private int LookAround(float a)//please dont touch
    {
        if (a <= 80 && a > 70)//look up
            return 1;
        if (a <= 70 && a > 60)
            return 2;
        if (a <= 60 && a > 50)
            return 3;
        if (a <= 50 && a > 40)
            return 4;
        if (a <= 40 && a > 30)
            return 5;
        if (a <= 30 && a > 20)//swing up
            return 6;
        if (a <= 20 && a > 10)
            return 7;
        if (a <= 10 && a > 0)
            return 8;
        if (a <= 0 && a > -10)
            return 9;
        if (a <= -10 && a > -20)
            return 10;
        if (a <= -20 && a > -30)
            return 11;
        if (a <= -30 && a > -40)//look up left
            return 12;
        if (a <= -40 && a > -50)
            return 13;
        if (a <= -50 && a > -60)
            return 14;
        if (a <= -60 && a > -70)
            return 15;
        if (a <= -70 && a > -80)
            return 16;
        if (a <= -80 && a > -90)//look straight left
            return 17;
        if (a <= -90 && a > -100)//look down left
            return 18;
        if (a <= -100 && a > -110)
            return 19;
        if (a <= -110 && a > -130)//swing down around
            return 20;
        if (a <= -130 && a > -140)
            return 21;
        if (a <= -140 && a > -150)
            return 22;
        if (a <= -150 && a > -170)
            return 23;
        if (a <=  -170 && a < 170)//swing down
            return 24;
        if (a <= 170 && a > 150)
            return 25;
        if (a <= 150 && a > 120)
            return 26;
        if (a <= 120 && a > 100)
            return 27;
        if (a <= 100 && a > 90)
            return 28;
        return 0;
    }   

}

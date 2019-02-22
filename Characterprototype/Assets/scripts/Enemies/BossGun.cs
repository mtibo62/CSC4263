using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGun : MonoBehaviour
{
    public Sprite[] sprites; //sprites to animate
    public GameObject obj;
    public GameObject Player;

    private SpriteRenderer sr;

    private Vector2 ObjPos; //position of your object
    private Vector2 PlayerPos; //position of the mouse pointer
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
        PlayerPos = Player.transform.position;
        RelPos = PlayerPos - ObjPos;

        angle = Mathf.Atan2(RelPos.x, RelPos.y);

        angle = angle * Mathf.Rad2Deg;
        switch (LookAround(angle))
        {
            case 1:
                sr.sprite = sprites[5];//look up
                break;
            case 2:
                sr.sprite = sprites[4];
                break;
            case 3:
                sr.sprite = sprites[3];
                break;
            case 4:
                sr.sprite = sprites[2];
                break;
            case 5:
                sr.sprite = sprites[1];
                break;
            case 6:
                sr.sprite = sprites[0];//swing around
                break;
        }
    }
    private int LookAround(float a)//please dont touch
    {
        if (a > -40)//look up left
            return 1;
        if (a <= -40 && a > -50)
            return 2;
        if (a <= -50 && a > -60)
            return 3;
        if (a <= -60 && a > -70)
            return 4;
        if (a <= -70 && a > -80)
            return 5;
        if (a <= -80 && a > -90)//look straight left
            return 6;
        if (a <= -90 && a > -179)//look down left
            return 7;
        return 0;
    }
}

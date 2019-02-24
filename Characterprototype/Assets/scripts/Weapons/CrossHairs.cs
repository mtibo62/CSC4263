using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossHairs : MonoBehaviour {

    public Sprite aim;
    public Sprite fire;
    public Sprite noFire;

    public GameObject obj;
    public GameObject crosshairs;

    private SpriteRenderer sr;

    private Vector2 ObjPos; //position of your object
    private Vector2 MousePos; //position of the mouse pointer
    private Vector2 RelPos; //position of pointer relative to object

    private float angle; //degrees 

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        crosshairs.transform.position = MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    // Update is called once per frame
    void Update()
    {
        crosshairs.transform.position = MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        ObjPos = obj.transform.position;
        RelPos = MousePos - ObjPos;

        angle = Mathf.Atan2(RelPos.x, RelPos.y);

        angle = angle * Mathf.Rad2Deg;

        switch (isVisible(angle))
        {
            case 1:
                sr.sprite = noFire;
                break;
            case 0:
                sr.sprite = aim;
                break;
        }
        if (Input.GetMouseButtonDown(0))
            sr.sprite = fire;

    }   
    private int isVisible(float a)
    {
        if (a <= 30 && a > 0)
            return 1;
        if (a <= 0 && a > -30)
            return 1;
        if (a <= 180 && a > 130)
            return 1;
        if (a <= -130 && a > -179f)
            return 1;

        return 0;
    }
}

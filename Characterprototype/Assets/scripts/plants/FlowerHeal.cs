using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerHeal : MonoBehaviour
{
    public GameObject gm;
    public Sprite[] flowers;
    public Sprite[] animate;

    private int heal;
    private SpriteRenderer sr;
    public float FPS;

    void Start()
    {
        heal = 0;
        sr = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "waterdrop")//check to see if it is being watered
        {
            if (heal < 9)
            {
                heal++;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
        switch (heal)//change flower sprite based on its health level
        {
            case 0:
                sr.sprite = flowers[0];
                break;
            case 1:
                sr.sprite = flowers[1];
                break;
            case 2:
                sr.sprite = flowers[2];
                break;
            case 3:
                sr.sprite = flowers[3];
                break;
            case 4:
                sr.sprite = flowers[4];
                break;
            case 5:
                sr.sprite = flowers[5];
                break;
            case 6:
                sr.sprite = flowers[6];
                break;
            case 7:
                sr.sprite = flowers[7];
                break;
            case 8:
                sr.sprite = flowers[8];
                break;
            case 9://increment the score for healing it and add one more to trigger animation
                sr.sprite = flowers[9];
                gm.GetComponent<GameManager>().score += 50;
                heal++;
                break;
            case 10:
                int index = (int)(Time.timeSinceLevelLoad * FPS);
                index = index % animate.Length;
                sr.sprite = animate[index];
                break;
        }
    }
}

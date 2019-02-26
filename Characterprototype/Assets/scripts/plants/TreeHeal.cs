using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeHeal : MonoBehaviour
{
    public GameObject gm;
    public GameObject Apple;
    public Sprite[] tree;
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
            if (heal < 24)
            {
                heal++;
            }
        }
        if (col.gameObject.tag == "BossBullet")
        {
            if (heal > 0 && heal < 24)
                heal--;
        }
    }
    // Update is called once per frame
    void Update()
    {

        switch (heal)//change flower sprite based on its health level
        {
            case 0:
                sr.sprite = tree[0];
                break;
            case 6:
                sr.sprite = tree[1];
                break;
            case 9:
                sr.sprite = tree[2];
                break;
            case 12:
                sr.sprite = tree[3];
                break;
            case 15:
                sr.sprite = tree[4];
                break;
            case 18:
                sr.sprite = tree[5];
                break;
            case 21:
                sr.sprite = tree[6];
                break;
            case 24:
                sr.sprite = tree[7];
                GetComponent<IsHealed>().healed = true;
                gm.GetComponent<GameManager>().score += 200;
                GameObject hApple = Instantiate(Apple, transform.position, Quaternion.identity) as GameObject;
                heal++;
                break;
            case 25://increment the score for healing it and add one more to trigger animation
                //int index = (int)(Time.timeSinceLevelLoad * FPS);
                //index = index % animate.Length;
                //sr.sprite = animate[index];
                break;
        }
    }
}

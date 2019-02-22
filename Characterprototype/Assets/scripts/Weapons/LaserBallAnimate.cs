using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBallAnimate : MonoBehaviour
{

    public Sprite[] sprites; //sprites to animate
    public float FPS;

    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        int index = (int)(Time.timeSinceLevelLoad * FPS);
        index = index % sprites.Length;
        sr.sprite = sprites[index];

    }
}

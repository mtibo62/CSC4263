using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileVelocity : MonoBehaviour
{
    public GameObject target;
    public float power;

    private Vector2 targetPos;
    private Vector2 startPos;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private float distance;
    private float angle;
    private float angleCorrection;
    private float distanceFactor;
    private float x, y;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        if (target == null)
            targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        else
            targetPos = target.transform.position;

        startPos = gameObject.transform.position;

        distance = targetPos.x - startPos.x;
        angle = (float)Math.Atan2(targetPos.y - startPos.y, targetPos.x - startPos.x);
        distanceFactor = 1 / 1000;
        angleCorrection = (float)(Math.PI * 0.18) * (distance * distanceFactor);
        x = (float)Math.Cos(angle + angleCorrection) * power;
        y = (float)Math.Sin(angle + angleCorrection) * power;
        if (x < 0)
            sr.flipX = true;
        rb.velocity = new Vector2(x, y);
    }
}

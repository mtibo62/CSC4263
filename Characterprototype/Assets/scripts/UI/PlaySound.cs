using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{

    public AudioClip splash;
    private AudioSource soundFX;

    void Start()
    {
        soundFX = GetComponent<AudioSource>();
        soundFX.clip = splash;
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (gameObject.transform.tag == "waterdrop")
        {
            soundFX.Play();
        }
    }
}

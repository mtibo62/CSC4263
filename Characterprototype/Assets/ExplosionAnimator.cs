using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionAnimator : MonoBehaviour
{


    private AudioSource soundFx;
    public AudioClip laserFx;
    public AudioClip SplashFX;


    void Start()
    {
        soundFx = GetComponent<AudioSource>();
        soundFx.clip = laserFx;
    }
    private void Update()
    {
        soundFx.Play();
        Destroy(gameObject, .35f);
    }

}

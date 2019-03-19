using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireWeapon : MonoBehaviour
{

    public GameObject bulletPrefab;
    public GameObject waterdropPrefab;
    public GameObject iciclePrefab;
    public GameObject grenadePrefab;
    public GameObject boltPrefab;
    public GameObject[] tripPrefab;
    public GameObject obj;
    public GameObject inventory;

    private Vector2 ObjPos; //position of your object
    private Vector2 MousePos; //position of the mouse pointer
    private Vector2 RelPos; //position of pointer relative to object

    private float angle; //degrees 
    private int weaponType;
    

    private SpriteRenderer sr;
    private AudioSource soundFx;
    public AudioClip laserFx;
    public AudioClip SplashFX;
    public AudioClip IceFX;
    public AudioClip noobTube;
    public AudioClip BoltFX;


    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        soundFx = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ObjPos = obj.transform.position;
        MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RelPos = MousePos - ObjPos;

        angle = Mathf.Atan2(RelPos.x, RelPos.y);

        angle = angle * Mathf.Rad2Deg;
        weaponType = inventory.GetComponent<Inventory>().weaponType;

        if (sr.enabled)//does he have a gun?
        {
            if (Input.GetMouseButtonDown(0))
            {
                switch (canFire(angle))
                {
                    case 0:
                        switch (weaponType) {
                            case 1:
                                GameObject waterdrop = Instantiate(waterdropPrefab, transform.position, Quaternion.identity) as GameObject;
                                waterdrop.GetComponent<BulletCollision>().weaponType = weaponType;
                                soundFx.clip = SplashFX;
                                soundFx.Play();
                                break;
                            case 2:
                                GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity) as GameObject;
                                bullet.GetComponent<BulletCollision>().weaponType = weaponType;
                                soundFx.clip = laserFx;
                                soundFx.Play();
                                break;
                            case 3:
                                GameObject iceshot = Instantiate(iciclePrefab, transform.position, Quaternion.identity) as GameObject;
                                iceshot.GetComponent<BulletCollision>().weaponType = weaponType;
                                soundFx.clip = IceFX;
                                soundFx.Play();
                                break;
                            case 4:
                                GameObject grenade = Instantiate(grenadePrefab, transform.position, Quaternion.identity) as GameObject;
                                grenade.GetComponent<BulletCollision>().weaponType = weaponType;
                                soundFx.clip = noobTube;
                                soundFx.Play();
                                break;
                            case 5:
                                GameObject bolt = Instantiate(boltPrefab, transform.position, Quaternion.identity) as GameObject;
                                bolt.GetComponent<BulletCollision>().weaponType = weaponType;
                                soundFx.clip = BoltFX;
                                soundFx.Play();
                                break;
                            case 6:
                                GameObject trip1 = Instantiate(tripPrefab[0], transform.position, Quaternion.identity) as GameObject;
                                GameObject trip2 = Instantiate(tripPrefab[1], transform.position, Quaternion.identity) as GameObject;
                                GameObject trip3 = Instantiate(tripPrefab[2], transform.position, Quaternion.identity) as GameObject;
                                trip1.GetComponent<BulletCollision>().weaponType = weaponType;
                                soundFx.clip = BoltFX;
                                soundFx.Play();
                                break;
                        }
                    break;
                    case 1:
                        //do nothing
                        break;
                }
            }
        }
    }
    private int canFire(float a)
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

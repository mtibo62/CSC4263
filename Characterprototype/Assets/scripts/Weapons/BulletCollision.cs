using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    public GameObject anima;
    public GameObject Inventory;

    public int weaponType;
    private GameObject anim;

    void Start()
    {

    }

    // Update is called once per frame
    public void OnCollisionEnter2D(Collision2D other)
    {
        switch (weaponType)
        {
            case 1:
                break;
            case 2:
                anim = Instantiate(anima, transform.position, Quaternion.identity) as GameObject;
                break;
            case 3:
                anim = Instantiate(anima, transform.position, Quaternion.identity) as GameObject;
                break;
            case 15:
                anim = Instantiate(anima, transform.position, Quaternion.identity) as GameObject;
                break;
            default:
                Destroy(gameObject);
                break;
        }

        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    public GameObject LaserExplodeAnimation;
    public GameObject Inventory;

    private int weaponType;

    void Start()
    {
        weaponType = 2;

    }

    // Update is called once per frame
    public void OnCollisionEnter2D(Collision2D other)
    {
        //weaponType = Inventory.GetComponent<Inventory>().weaponType;
        switch (weaponType)
        {
            case 1:
                break;
            case 2:
                GameObject anim = Instantiate(LaserExplodeAnimation, transform.position, Quaternion.identity) as GameObject;
                break;
            default:
                Destroy(gameObject);
                break;
        }
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpWeapon : MonoBehaviour
{
    public GameObject gun;
    public GameObject inv;
    public GameObject inventory;
    SpriteRenderer sr;
    SpriteRenderer srv;

    public int weaponType;

    public Text instructions;
    // Start is called before the first frame update
    void Start()
    {
        sr = gun.GetComponent<SpriteRenderer>();
        srv = inv.GetComponent<SpriteRenderer>();
        sr.enabled = false;
        srv.enabled = false;
        instructions.text = "";
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            instructions.text = "Press E to pick up...";
        }

    }
    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (Input.GetKey("e"))
            {
                switch (weaponType)
                {
                    case 1:
                        gun.GetComponent<RotationAnimationWeapons>().water = true;
                        break;
                    case 2:
                        gun.GetComponent<RotationAnimationWeapons>().laser = true;
                        break;
                    case 3:
                        gun.GetComponent<RotationAnimationWeapons>().ice = true;
                        break;
                }
                sr.enabled = true;
                srv.enabled = true;
                inventory.GetComponent<Inventory>().weaponType = weaponType;
                inventory.GetComponent<Inventory>().inventory.Add(weaponType);
                inventory.GetComponent<Inventory>().inventory.Sort();
                Destroy(gameObject);
                instructions.text = "";
            }
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        instructions.text = "";
    }
    void Update()
    {

        
    }
}

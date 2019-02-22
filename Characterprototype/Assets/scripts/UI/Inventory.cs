using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int weaponType;
    public List<int> inventory;

    private int select;
    // Start is called before the first frame update
    void Start()
    {
        weaponType = 0;
        select = 0;
        inventory = new List<int>();

    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown("c")) // forward
        {
            if (inventory.Count > 1) {//this prevents a bug where you could change to a weapon you didn't have. So you could access it but not fire it
                select++;
                if (select < inventory.Count)
                    weaponType = inventory[select];
                else
                    select--;
                    }
        }
        else if (Input.GetKeyDown("x")) // backwards
        {
            if (inventory.Count > 1 && select > 0)
            {
                select--;
                weaponType = inventory[select];
            }
        }
    }
}

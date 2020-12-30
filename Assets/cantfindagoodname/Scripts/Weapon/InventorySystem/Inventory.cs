using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    public List<Weapon> inventory;
    private int maxSize = 2, current = 0, previous = 0;
    private void Awake()
    {
        inventory.Add(GetComponent<CurrentWeapon>().currentWeapon);
    }
    private void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") != 0f)
        {
            previous = current;
            current = (current + 1) % inventory.Count;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            int temp;
            temp = previous;
            previous = current;
            current = temp;
        }
        if (inventory[current] != GetComponent<CurrentWeapon>().currentWeapon)
        {
            GetComponent<CurrentWeapon>().currentWeapon = inventory[current];
        }
    }
    public Weapon insertToInventory(Weapon insertion) // return insertion : destroy gameObject
    {
        for (int i = 0; i < inventory.Count; ++i) 
        {
            if (inventory[i] == insertion)
            {
                int temp = current;
                current = i;
                if (previous == current)
                    previous = temp;
                // add ammo, return insertion
                return insertion;
            }
        }

        if (inventory.Count < maxSize)
        {
            inventory.Add(insertion);
            previous = current;
            current = inventory.Count - 1;
            return insertion;
        }
        else
        {
            Weapon temp = inventory[current];
            inventory[current] = insertion;
            return temp;
        }
    }
}

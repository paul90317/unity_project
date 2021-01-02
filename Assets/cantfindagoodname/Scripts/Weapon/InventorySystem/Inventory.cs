using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    public GameObject Display1, Display2;
    public List<Weapon> inventory;
    private int maxSize = 2, previous = 0;
    public int current = 1;
    private void Awake()
    {
        inventory.Add(GetComponent<CurrentWeapon>().currentWeapon);

        Display1.GetComponent<DisplayWeapons>().setImage(inventory[current].currentWeaponSprite);
        Display2.GetComponent<DisplayWeapons>().setImage(inventory[previous].currentWeaponSprite);
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

            Display1.GetComponent<DisplayWeapons>().setImage(inventory[current].currentWeaponSprite);
            Display2.GetComponent<DisplayWeapons>().setImage(inventory[previous].currentWeaponSprite);
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

                // level up
                ++GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<DamageAmplify>().level;

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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializePickUp : MonoBehaviour {
    public GameObject weaponList;

    private Weapon thisWeapon;
    private SpriteRenderer sr;
    private BoxCollider2D boxCollider;

    private static System.Random rand = new System.Random();

    private bool playerEnter;

    private void Awake()
    {
        thisWeapon = weaponList.GetComponent<WeaponList>().weapons[rand.Next(weaponList.GetComponent<WeaponList>().weapons.Count)];

        sr = GetComponent<SpriteRenderer>();
        sr.sprite = thisWeapon.currentWeaponSprite;

        boxCollider = GetComponent<BoxCollider2D>();
        boxCollider.size = sr.bounds.size;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerEnter == true) 
        {
            Weapon temp = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Inventory>().insertToInventory(thisWeapon);
            if (thisWeapon == temp)
                Destroy(gameObject);
            else
            {
                thisWeapon = temp;
                sr.sprite = thisWeapon.currentWeaponSprite;
            }
            playerEnter = false;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerEnter = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerEnter = false;
        }
    }
}

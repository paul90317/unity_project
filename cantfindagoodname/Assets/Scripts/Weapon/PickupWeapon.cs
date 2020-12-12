using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupWeapon : MonoBehaviour {
    public Weapon weapon;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponentInChildren<Fire>().currentWeapon = weapon;
            GameObject.FindGameObjectWithTag("Weapon").GetComponent<SpriteRenderer>().sprite=weapon.currentWeaponSprite;
            //Destroy(gameObject);
        }
    }
}

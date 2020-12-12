using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppedWeapon : MonoBehaviour {
    public Weapon weapon;
    private void Awake()
    {
        if (weapon)
        {
            GetComponent<SpriteRenderer>().sprite = weapon.picture;
            GetComponent<SpriteRenderer>().size = weapon.size;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (weapon && collision.tag == "Player" && Input.GetKeyDown(KeyCode.F))
        {
            collision.transform.GetChild(1).SendMessage("pickup", weapon);
            Destroy(gameObject);
        }
    }
    public void drop(Weapon _weapon)
    {
        weapon = _weapon;
        GetComponent<SpriteRenderer>().sprite = weapon.picture;
        GetComponent<SpriteRenderer>().size = weapon.size;
    }
}

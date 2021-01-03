using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {
    private void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            GetComponent<CurrentWeapon>().currentWeapon.Shoot();
            GetComponentInParent<Ammo>().resetCombatTimer();
        }
        else if (Input.GetButtonUp("Fire1"))
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<movementScript>().weaponOffset = 1f;

            GameObject.FindGameObjectWithTag("GameController").transform.GetChild(0).GetComponent<LineRenderer>().SetPosition(0, Vector2.zero);
            GameObject.FindGameObjectWithTag("GameController").transform.GetChild(0).GetComponent<LineRenderer>().SetPosition(1, Vector2.zero);
        }
    }
}


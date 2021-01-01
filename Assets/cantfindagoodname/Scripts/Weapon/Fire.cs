using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {
    private void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            GetComponent<CurrentWeapon>().currentWeapon.Shoot();
        }
        else if (Input.GetButtonUp("Fire1"))
        {
            GameObject.FindGameObjectWithTag("GameController").transform.GetChild(0).GetComponent<LineRenderer>().SetPosition(0, Vector2.zero);
            GameObject.FindGameObjectWithTag("GameController").transform.GetChild(0).GetComponent<LineRenderer>().SetPosition(1, Vector2.zero);
        }
    }
}


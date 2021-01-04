using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentWeapon : MonoBehaviour {
    private Weapon previousWeapon;
    public Weapon currentWeapon;
    private void Awake()
    {
        previousWeapon = currentWeapon;
    }
    void Update () {
        if (previousWeapon != currentWeapon)
        {
            GameObject.FindGameObjectWithTag("GameController").transform.GetChild(0).GetComponent<LineRenderer>().SetPosition(0, Vector2.zero);
            GameObject.FindGameObjectWithTag("GameController").transform.GetChild(0).GetComponent<LineRenderer>().SetPosition(1, Vector2.zero);

            previousWeapon = currentWeapon;
            GetComponent<SpriteRenderer>().sprite = currentWeapon.currentWeaponSprite;

            GetComponent<DamageAmplify>().level = currentWeapon.currentLevel;
        }
        if (GetComponent<SpriteRenderer>().size.x != currentWeapon.width || GetComponent<SpriteRenderer>().size.y != currentWeapon.height)
        {
            GetComponent<SpriteRenderer>().size = new Vector2(currentWeapon.width, currentWeapon.height);
        }
	}
}

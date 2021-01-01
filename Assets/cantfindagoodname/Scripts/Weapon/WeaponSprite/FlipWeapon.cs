using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipWeapon : MonoBehaviour {
    private SpriteRenderer sr;
    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = GetComponent<CurrentWeapon>().currentWeapon.currentWeaponSprite;
    }
    void Update () {
        sr.flipY = (Mathf.Abs(transform.localEulerAngles.z - 180f) < 90f);
	}
}

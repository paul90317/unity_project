using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour {
    public AmmoBar ammoBar;

    public int maxAmmo;
    private int _AMMO;

    private float inCombatTime, combatTagTime;
    private void Awake()
    {
        maxAmmo = 180;
        ammo = maxAmmo;
        ammoBar.setMaxAmmo(maxAmmo);

        combatTagTime = 5f;
    }
    private void Update()
    {
        if (ammo < maxAmmo)
        {
            if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHP>().inCombat == false && inCombatTime < Time.time) 
            {
                ammo += 1;
            }
        }
    }
    public int ammo
    {
        get { return _AMMO; }
        set
        {
            if (value > maxAmmo)
            {
                _AMMO = maxAmmo;
            }
            else if (value <= 0)
            {
                _AMMO = 0;
            }
            else
            {
                _AMMO = value;
            }
            ammoBar.setAmmo(ammo);
        }
    }
    public void resetCombatTimer()
    {
        inCombatTime = Time.time + combatTagTime;
    }
}

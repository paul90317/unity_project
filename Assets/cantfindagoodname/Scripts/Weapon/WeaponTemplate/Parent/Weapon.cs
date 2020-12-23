using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : ScriptableObject
{
    public Sprite currentWeaponSprite;
    public float handDistance;
    public int damage;
    public abstract void Shoot();
}

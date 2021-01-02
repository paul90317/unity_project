using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : ScriptableObject
{
    [Header("Transform")]
    public Sprite currentWeaponSprite;
    public float width, height;
    public float handDistance;
    [Space]
    [Header("In Game parameters")]
    public int currentLevel;
    public int damage;
    public abstract void Shoot();
}

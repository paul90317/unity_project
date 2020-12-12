using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Weapon", menuName="Weapon", order =30)]
public class Weapon : ScriptableObject
{
    public Sprite currentWeaponSprite;

    public GameObject bulletPrefab;
    public GameObject hitParticle;
    public LineRenderer railgunLine;

    public bool isRailgun;

    public float fireRate = 1;
    public int damage;

    public void Shoot()
    {
        if (isRailgun == false)
        {
            GameObject bullet = Instantiate(bulletPrefab, GameObject.FindGameObjectWithTag("FirePoint").transform.position, Quaternion.identity);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Projectile Weapon", menuName = "Weapon/ProjectileWeapon", order =30)]
public class ProjectileWeapon : Weapon {

    public GameObject bulletPrefab;
    public float fireRate;

    private Vector2 firePoint;
    private float delayTime;

    public override void Shoot()
    {
        if (delayTime >= 10)
        {
            firePoint = (Vector2)GameObject.FindGameObjectWithTag("Player").transform.position + (Vector2)GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).transform.right * handDistance;
            Instantiate(bulletPrefab, firePoint, Quaternion.identity);

            delayTime = 0;
        }
        else
        {
            delayTime += Time.deltaTime * fireRate;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Projectile Weapon", menuName = "Weapon/ProjectileWeapon", order =30)]
public class ProjectileWeapon : Weapon {

    public GameObject bulletPrefab;
    public float fireRate;
    public int ammoConsumption;

    private Vector2 firePoint;
    private float cooldownEnd;

    public override void Shoot()
    {
        if (GameObject.FindGameObjectWithTag("Player").transform.GetComponent<Ammo>().ammo > 0 && Time.time > cooldownEnd) 
        {
            firePoint = (Vector2)GameObject.FindGameObjectWithTag("Player").transform.position + (Vector2)GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).transform.right * handDistance;
            Instantiate(bulletPrefab, firePoint, Quaternion.identity);

            cooldownEnd = Time.time + 1 / fireRate;

            GameObject.FindGameObjectWithTag("Player").transform.GetComponent<Ammo>().ammo -= ammoConsumption;
        }
    }
    private void OnEnable()
    {
        cooldownEnd = 0f;
    }
}

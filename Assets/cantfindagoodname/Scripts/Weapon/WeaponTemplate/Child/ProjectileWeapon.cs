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
        if (GameObject.FindGameObjectWithTag("Player").transform.GetComponent<Ammo>().ammo > 0)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<movementScript>().weaponOffset = (0.6f + 0.1f * GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<DamageAmplify>().level) % 1;
            if (Time.time > cooldownEnd)
            {
                firePoint = (Vector2)GameObject.FindGameObjectWithTag("Player").transform.position + (Vector2)GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).transform.right * handDistance;
                Instantiate(bulletPrefab, firePoint, Quaternion.identity);

                cooldownEnd = Time.time + 1 / fireRate;

                GameObject.FindGameObjectWithTag("Player").transform.GetComponent<Ammo>().ammo -= ammoConsumption;
            }
        }
        else
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<movementScript>().weaponOffset = 1f;
        }
    }
    private void OnEnable()
    {
        cooldownEnd = 0f;
    }
}

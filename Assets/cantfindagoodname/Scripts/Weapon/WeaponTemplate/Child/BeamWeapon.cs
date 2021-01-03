using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Beam Weapon", menuName = "Weapon/BeamWeapon", order =31)]
public class BeamWeapon : Weapon {

    public GameObject hitParticle;
    public float ammoConsumptionTick;

    private float consumeAmmo;
    private LineRenderer railgunLine;
    private LayerMask raycastLayer;
    private Vector2 firePoint;
    public void Awake()
    {
        raycastLayer = LayerMask.GetMask("Wall") | LayerMask.GetMask("Enemy");
    }
    public override void Shoot()
    {
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<Ammo>().ammo > 0)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>().PlayOneShot(GameObject.FindObjectOfType<SFX>().shootBeam, 0.3f);

            GameObject.FindGameObjectWithTag("Player").GetComponent<movementScript>().weaponOffset = 0.1f;

            railgunLine = GameObject.FindGameObjectWithTag("GameController").transform.GetChild(0).GetComponent<LineRenderer>();
            firePoint = (Vector2)GameObject.FindGameObjectWithTag("Player").transform.position + (Vector2)GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).transform.right * handDistance;

            Vector2 dir = (firePoint - (Vector2)GameObject.FindGameObjectWithTag("Player").transform.position).normalized;
            RaycastHit2D hit = Physics2D.Raycast(firePoint, dir, float.PositiveInfinity, raycastLayer);

            if (hit && (hit.collider.CompareTag("monster") || hit.collider.CompareTag("Wall") || hit.collider.CompareTag("box"))) 
            {
                if (hit.collider.CompareTag("monster"))
                {
                    Instantiate(hitParticle, hit.point, Quaternion.identity);

                    hit.collider.GetComponent<monsterHealth>().hurt(damage+(GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).GetComponent<DamageAmplify>().level));
                }
                railgunLine.SetPosition(0, firePoint);
                railgunLine.SetPosition(1, hit.point);
            }
            else
            {
                railgunLine.SetPosition(0, GameObject.FindGameObjectWithTag("Player").transform.position);
                railgunLine.SetPosition(1, GameObject.FindGameObjectWithTag("Player").transform.position);
            }
            if (Time.time > consumeAmmo)
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<Ammo>().ammo -= 10 / ((GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<DamageAmplify>().level + 1) % 10);
                consumeAmmo = Time.time + ammoConsumptionTick / 100;
            }
        }
        else
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<movementScript>().weaponOffset = 1f;

            railgunLine.SetPosition(0, GameObject.FindGameObjectWithTag("Player").transform.position);
            railgunLine.SetPosition(1, GameObject.FindGameObjectWithTag("Player").transform.position);
        }
    }
    private void OnEnable()
    {
        consumeAmmo = 0f;
    }
}

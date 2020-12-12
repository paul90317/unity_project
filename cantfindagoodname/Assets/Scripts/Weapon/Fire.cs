using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {
    public Weapon currentWeapon;
    public LineRenderer railgunLine;

    private float delayTime = 0;
    private LayerMask raycastLayer;
    private void Awake()
    {
        raycastLayer = LayerMask.GetMask("Wall") | LayerMask.GetMask("Enemy");
        GetComponent<SpriteRenderer>().sprite = GetComponent<Fire>().currentWeapon.currentWeaponSprite;
    }
    private void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            if (currentWeapon.isRailgun == false)
            {
                if (Time.time >= delayTime)
                {
                    currentWeapon.Shoot();
                    delayTime = Time.time + 1 / currentWeapon.fireRate;
                }
            }
            else
            {
                Vector2 dir = (GameObject.FindGameObjectWithTag("ReferenceShootingDirection").transform.position - GameObject.FindGameObjectWithTag("FirePoint").transform.position).normalized;
                RaycastHit2D hit = Physics2D.Raycast(GameObject.FindGameObjectWithTag("FirePoint").transform.position, dir, float.PositiveInfinity, raycastLayer);
                if (hit)
                {
                    if (hit.collider.CompareTag("Enemy"))
                    {
                        Instantiate(currentWeapon.hitParticle, hit.point, Quaternion.identity);
                    }
                    railgunLine.SetPosition(0, GameObject.FindGameObjectWithTag("FirePoint").transform.position);
                    railgunLine.SetPosition(1, hit.point);
                }
            }
        }
        else
        {
            railgunLine.SetPosition(0, Vector2.zero);
            railgunLine.SetPosition(1, Vector2.zero);
        }
        if (currentWeapon.isRailgun == false)
        {
            railgunLine.SetPosition(0, Vector2.zero);
            railgunLine.SetPosition(1, Vector2.zero);
        }
    }
}


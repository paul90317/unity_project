using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Beam Weapon", menuName = "Weapon/BeamWeapon", order =31)]
public class BeamWeapon : Weapon {

    public GameObject hitParticle;

    private LineRenderer railgunLine;
    private LayerMask raycastLayer;
    private Vector2 firePoint;
    public void Awake()
    {
        raycastLayer = LayerMask.GetMask("Wall") | LayerMask.GetMask("Enemy");
    }
    public override void Shoot()
    {
        railgunLine = GameObject.FindGameObjectWithTag("GameController").transform.GetChild(0).GetComponent<LineRenderer>();
        firePoint = (Vector2)GameObject.FindGameObjectWithTag("Player").transform.position + (Vector2)GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).transform.right * handDistance;

        Vector2 dir = (firePoint - (Vector2)GameObject.FindGameObjectWithTag("Player").transform.position).normalized;
        RaycastHit2D hit = Physics2D.Raycast(firePoint, dir, float.PositiveInfinity, raycastLayer);

        if (hit&&(hit.collider.CompareTag("monster")||hit.collider.CompareTag("Wall")))
        {
            if (hit.collider.CompareTag("monster"))
            {
                Instantiate(hitParticle, hit.point, Quaternion.identity);
            }
            railgunLine.SetPosition(0, firePoint);
            railgunLine.SetPosition(1, hit.point);
        }
        else
        {
            railgunLine.SetPosition(0, GameObject.FindGameObjectWithTag("Player").transform.position);
            railgunLine.SetPosition(1, GameObject.FindGameObjectWithTag("Player").transform.position);
        }
    }
}

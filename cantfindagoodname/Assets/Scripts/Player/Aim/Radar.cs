using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class Radar : MonoBehaviour {

    public bool enemyInRange;
    public Vector3 enemyPos;
    private CircleCollider2D radar;
    private void Awake()
    {
        radar = GetComponent<CircleCollider2D>();
        Physics2D.IgnoreCollision(radar, GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(radar, GameObject.FindGameObjectWithTag("Radar").GetComponent<Collider2D>());
    }
    private void Update()
    {
        if (radar.radius >= 30f)
        {
            radar.radius = 0f;
            enemyInRange = false;
        }
        else
            radar.radius += 1f;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Vector2 vectorToEnemy = collision.transform.position - transform.position;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, vectorToEnemy, float.PositiveInfinity, LayerMask.GetMask("Wall") | LayerMask.GetMask("Enemy"));
            if (hit.collider.gameObject.CompareTag("Enemy"))
            {
                radar.radius = 0f;
                enemyPos = collision.gameObject.transform.position;
                enemyInRange = true;
            }
            else
            {
                enemyInRange = false;
            }
        }
    }
}

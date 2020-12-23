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
    }
    private void Update()
    {
        if (radar.radius >= 30f)
        {
            radar.radius = 0f;
            enemyInRange = false;
        }
        else if (radar.radius > 20f)
            radar.radius += 1f;
        else
            radar.radius += 0.5f;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("monster"))
        {
            Vector2 vectorToEnemy = collision.transform.position - transform.position;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, vectorToEnemy, float.PositiveInfinity, LayerMask.GetMask("Wall") | LayerMask.GetMask("Enemy"));
            if (hit.collider.gameObject.CompareTag("monster"))
            {
                Debug.DrawLine(collision.transform.position, transform.position);
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

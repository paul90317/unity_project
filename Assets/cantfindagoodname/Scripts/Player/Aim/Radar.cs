using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class Radar : MonoBehaviour {

    public bool enemyInRange;
    public Vector3 enemyPos;
    private CircleCollider2D radar;

    public float detectRange;
    private void Awake()
    {
        radar = GetComponent<CircleCollider2D>();
        Physics2D.IgnoreCollision(radar, GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>());

        radar.radius = 0;
    }
    private void Update()
    {
        if (radar.radius >= detectRange)
        {
            radar.radius = 0f;
            enemyInRange = false;
        }
        else if (radar.radius > 2 * detectRange / 3) 
            radar.radius += 1.5f;
        else
            radar.radius += 1f;
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

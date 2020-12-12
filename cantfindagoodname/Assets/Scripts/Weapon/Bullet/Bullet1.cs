using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet1 : MonoBehaviour {

    private Rigidbody2D rb;
    private float bulletForce = 20f;
    private Vector2 shootingDirection;
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        shootingDirection = (GameObject.FindGameObjectWithTag("ReferenceShootingDirection").transform.position 
                           - GameObject.FindGameObjectWithTag("FirePoint").transform.position).normalized;
	}
	
	void Update () {
        rb.AddForce(shootingDirection * bulletForce, ForceMode2D.Impulse);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
            Destroy(gameObject);
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}

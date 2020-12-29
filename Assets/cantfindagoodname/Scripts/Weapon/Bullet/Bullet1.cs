using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet1 : MonoBehaviour {

    private Rigidbody2D rb;
    private float bulletForce = 5f;
    private Vector2 shootingDirection;

    private int damage;

	void Start () {

        rb = GetComponent<Rigidbody2D>();
        shootingDirection = ((Vector2)GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).transform.right).normalized;

        damage = GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).GetComponent<CurrentWeapon>().currentWeapon.damage;

        Destroy(gameObject, 10f);
	}
	
	void Update () {
        rb.AddForce(shootingDirection * bulletForce, ForceMode2D.Impulse);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
            Destroy(gameObject);
        else if (collision.gameObject.CompareTag("monster"))
        {
            collision.GetComponent<monsterHealth>().hurt(damage);
            Destroy(gameObject);
        }
    }
}

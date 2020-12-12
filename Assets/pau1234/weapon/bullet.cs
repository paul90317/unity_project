using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {

    public float speed;
    public int damage;
	void Update () {
        GetComponent<Rigidbody2D>().velocity = transform.right * speed;
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "monster")
        {
            collision.gameObject.SendMessage("hurt", damage);
        }
        Destroy(gameObject);
    }
}

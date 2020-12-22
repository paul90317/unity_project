using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {

    public float speed;
    public int damage;
    Vector3 dir;

    private void Start()
    {
        dir = GetComponent<Rigidbody2D>().velocity = transform.right;
    }
    void Update () {
        GetComponent<Rigidbody2D>().velocity = dir * speed;
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "monster" || collision.transform.tag == "box")
        {
            collision.gameObject.SendMessage("hurt", damage);
        }
        if (!collision.GetComponent<Collider2D>().isTrigger)
        {
            Destroy(gameObject);
        }
    }
}

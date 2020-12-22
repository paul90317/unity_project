using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxHealth : MonoBehaviour {

    public int health;
    public int n;
    public GameObject item;

    public void hurt(int damage)
    {
        health -= damage;
    }

    private void Update()
    {
        if (health <= 0)
        {
            shoot();
            Destroy(gameObject);
        }
    }

    void shoot()
    {
        float d = 360f / n;
        for(int i = 0; i < n; i++)
        {
            GetComponent<BoxCollider2D>().enabled = false;
            GameObject t = Instantiate<GameObject>(item);
            t.transform.Rotate(0, 0, i * d);
            t.transform.position = transform.position;
        }
    }
}

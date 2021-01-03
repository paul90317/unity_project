using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour {
    [SerializeField]
    public float health = 30;

    private void Update()
    {
        if (health <= 0)
        {
            deathEffect();
            Destroy(gameObject);
        }
    }

    public void takeDamage(int damage)
    {
        health -= damage;
    }
    private void deathEffect()
    {
        return;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterHealth : MonoBehaviour {

    public int health;
	
    public void hurt(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            if (tag == "monster")
            {
                transform.parent.gameObject.SendMessage("removeMonster");
            }
            Destroy(gameObject);
        }
    }
}

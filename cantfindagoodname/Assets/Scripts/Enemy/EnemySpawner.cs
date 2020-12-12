using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject Enemy;
    System.Random rnd = new System.Random();
    public int[] xBound, yBound;

    private void Start()
    {
        StartCoroutine(spawnEnemy());
    }

    IEnumerator spawnEnemy()
    {
        yield return new WaitForSeconds(2);
        if (GameObject.FindGameObjectsWithTag("Enemy").Length < 2) 
        {
            Vector2 spawnPoint = new Vector2(rnd.Next(xBound[0], xBound[1]), rnd.Next(yBound[0], yBound[1]));
            Instantiate(Enemy, spawnPoint, Quaternion.identity);
        }
        StartCoroutine(spawnEnemy());
    }
}

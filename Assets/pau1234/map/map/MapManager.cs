using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapManager : MonoBehaviour {
    System.Random r;
    public GameObject[] maps;
    public GameObject[] bossMap;
    public int maxLevel;
    int cnt;
    int state;
    int id;
    GameObject currentMap;
	// Use this for initialization
	void Awake() {
        cnt = 0;
        r = new System.Random(System.Guid.NewGuid().GetHashCode());
        id = r.Next(maps.Length);
        state = SceneManager.GetActiveScene().buildIndex;
        if (maps.Length > 0)
        {
            currentMap = Instantiate<GameObject>(maps[id]);
        }
    }
    public IEnumerator NextScene()
    {
        cnt++;
        if (currentMap)
        {
            Destroy(currentMap);
        }
        yield return new WaitForSeconds(0.1f);
        if (cnt < maxLevel)
        {
            currentMap = Instantiate<GameObject>(maps[id]);
        }
        else if(cnt==maxLevel)
        {
            currentMap = Instantiate<GameObject>(bossMap[id]);
        }
        else
        {
            SceneManager.LoadScene(state + 1);
        }
    }
}

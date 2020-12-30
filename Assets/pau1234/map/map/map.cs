using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class map : MonoBehaviour {
    public int MAX_GRID;
    public TextAsset[] maps;
    int[,] imap;
    GameObject[,] gmap;
    public GameObject normal_room1;
    public GameObject walker2;
    System.Random r;
    public GameObject home_room3;
    public GameObject[] boss_room4;
    public GameObject gate_room5;
    public GameObject[] special_room6;
	// Use this for initialization
	void Awake() {
        r = new System.Random(System.Guid.NewGuid().GetHashCode());
        char[] ignore = { ' ', '\r', '\n' };
        string[] input2 = maps[r.Next(maps.Length)].ToString().Split(ignore);
        len = int.Parse(input2[0]);
        wid = int.Parse(input2[1]);
        imap = new int[len,wid];
        gmap = new GameObject[len, wid];
        for(int i = 0, k = 2; i < wid; i++)
        {
            for(int j = 0; j < len; j++,k++)
            {
                while (input2[k].Length==0) k++;
                imap[j, wid-i-1] = int.Parse(input2[k]);
            }
        }
        for(int i = 0; i < len; i++)
        {
            for(int j = 0; j < wid; j++)
            {
                if (imap[i, j] == 3) 
                {
                    dfs(i, j);
                    break;
                }
            }
        }
        
	}
    int len, wid;
    void dfs(int i,int j)
    {
        if (i < 0 || j < 0 || i >= len || j >= wid||imap[i, j] == 0 )
        {
            return;
        }
        switch(imap[i, j])
        {
            case 2:
                imap[i, j] = 0;
                dfs(i + 1, j);
                dfs(i - 1, j);
                dfs(i, j + 1);
                dfs(i, j - 1);
                gmap[i, j] = Instantiate<GameObject>(walker2, transform);
                gmap[i, j].transform.localPosition = walker_v(i, j);
                if (i % 2 == 0) gmap[i, j].SendMessage("vertical");
                gmap[i, j].SendMessage("shot");
                return;
            case 1:
                gmap[i, j] = Instantiate<GameObject>(normal_room1, transform);
                break;
            case 3:
                gmap[i, j] = Instantiate<GameObject>(home_room3, transform);
                GameObject player = GameObject.FindWithTag("Player");
                if (player)
                {
                    player.transform.position = transform.position + new Vector3(i / 2 * MAX_GRID + MAX_GRID / 2, j / 2 * MAX_GRID + MAX_GRID / 2, -1);
                }
                break;
            case 4:
                gmap[i, j] = Instantiate<GameObject>(boss_room4[r.Next(boss_room4.Length)], transform);
                break;
            case 5:
                gmap[i, j] = Instantiate<GameObject>(gate_room5, transform);
                break;
            case 6:
                gmap[i, j] = Instantiate<GameObject>(special_room6[r.Next(special_room6.Length)], transform);
                break;
        }
        int x = i / 2;
        int y = j / 2;
        gmap[i, j].transform.localPosition += new Vector3(x * MAX_GRID, y * MAX_GRID, 0);
        imap[i, j] = 0;
        dfs(i + 1, j);
        dfs(i - 1, j);
        dfs(i, j + 1);
        dfs(i, j - 1);
    }
    Vector3 walker_v(int i,int j)
    {
        if (i % 2 == 1)
        {
            return new Vector3((i / 2 + 1) * MAX_GRID, j / 2 * MAX_GRID + MAX_GRID / 2, 0);
        }
        return new Vector3(i / 2 * MAX_GRID + MAX_GRID / 2, (j / 2 + 1) * MAX_GRID, 0);
    }
}

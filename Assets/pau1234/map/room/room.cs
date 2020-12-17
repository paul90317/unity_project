using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class room : MonoBehaviour {
    public int MAX_GRID;
    public RoomData[] rooms;
    public GameObject[] block;
    public GameObject[] monster;
    public GameObject[] treasure;
    public GameObject sensor;
    public GameObject gate;
    
    GameObject[,] gmap;

    int len, wid;
    int lv, cnt;

    System.Random r;
    Vector2Int[] space;
    int[] monsterWave;

    GameObject gmake(int x,int y,GameObject g,int layer=0)
    {
        var gtmp = Instantiate<GameObject>(g, transform);
        gtmp.transform.localPosition = new Vector3(x, y, layer);
        return gtmp;
    }

    // Use this for initialization
    void Awake () {
        Df = Uf = Rf = Lf = false;
        r = new System.Random(System.Guid.NewGuid().GetHashCode());
        space = new Vector2Int[0];

        int id = r.Next(rooms.Length);
        int[] input2 = myMethod.get_arr(rooms[id].roomMap.ToString());
        len = input2[0];
        wid = input2[1];
        transform.localPosition = new Vector3(MAX_GRID / 2 - len / 2, MAX_GRID / 2 - wid / 2);
        
        gmap = new GameObject[len, wid];
        int k = 2;
        for(int i = 0; i < wid ; i++)
        {
            for(int j = 0; j < len; j++,k++)
            {
                if (input2[k] == 0)
                {
                    System.Array.Resize(ref space, space.Length + 1);
                    space[space.Length - 1] = new Vector2Int(j, wid - i - 1);
                    continue;
                }
                gmap[j, wid - i - 1] = gmake(j, wid - i - 1, block[input2[k]]);
            }
        }
        GameObject backfloor = gmake(len / 2, wid / 2, block[0]);
        backfloor.GetComponent<SpriteRenderer>().size = new Vector2(len - 2, wid - 2);

        monsterWave = rooms[id].monsterWave;

        lv = cnt = 0;
	}
    // Update is called once per frame
    void Update()
    {
        if ( lv > monsterWave.Length)
        {
            return;
        }
        if (tag == "start")
        {
            Debug.Log("max=" + monsterWave.Length.ToString() + " lv=" + lv.ToString() + " cnt=" + cnt.ToString());
        }
        
        if (cnt == 0)
        {
            lv++;
            if (lv > monsterWave.Length)
            {
                tag = "finish";
                if (treasure.Length > 0)
                {
                    gmake(len / 2, wid / 2, treasure[r.Next(treasure.Length)]);
                }
                return;
            }
            for(int i = 0; i < monsterWave[lv-1]; i++)
            {
                int id = r.Next(space.Length);
                gmake(space[id].x, space[id].y, monster[r.Next(monster.Length)]);
                cnt++;
            }
        }
    }
    bool Lf;
    public void gateL()
    {
        if (Lf) return;
        Lf = true;
        Destroy(gmap[0, wid / 2 - 1]);
        Destroy(gmap[0, wid / 2]);
        Destroy(gmap[0, wid / 2 + 1]);
        gmake(0, wid / 2 - 1, gate);
        gmake(0, wid / 2, gate);
        gmake(0, wid / 2 + 1, gate);
        var sen = Instantiate<GameObject>(sensor, transform);
        sen.transform.localPosition = new Vector3(1.5f, wid / 2, 0);
    }
    bool Rf;
    public void gateR()
    {
        if (Rf) return;
        Rf = true;
        Destroy(gmap[len - 1, wid / 2 - 1]);
        Destroy(gmap[len - 1, wid / 2]);
        Destroy(gmap[len - 1, wid / 2 + 1]);
        gmake(len - 1, wid / 2 - 1, gate);
        gmake(len - 1, wid / 2, gate);
        gmake(len - 1, wid / 2 + 1, gate);
        var sen = Instantiate<GameObject>(sensor, transform);
        sen.transform.localPosition = new Vector3(len - 2.5f, wid / 2, 0);
    }
    bool Uf;
    public void gateU()
    {
        if (Uf) return;
        Uf = true;
        Destroy(gmap[len/2 + 1, wid-1]);
        Destroy(gmap[len/2 , wid-1]);
        Destroy(gmap[len/2 - 1, wid -1]);
        gmake(len/2 + 1, wid - 1, gate);
        gmake(len/2, wid - 1, gate);
        gmake(len / 2 - 1, wid - 1, gate);
        var sen = Instantiate<GameObject>(sensor, transform);
        sen.transform.localPosition = new Vector3(len/2, wid -2.5f, 0);
        sen.transform.Rotate(0, 0, 90);
    }
    bool Df;
    public void gateD()
    {
        if (Df) return;
        Df = true;
        Destroy(gmap[len/2 + 1,0]);
        Destroy(gmap[len/2, 0]);
        Destroy(gmap[len / 2 - 1,0]);
        gmake(len/2 + 1, 0, gate);
        gmake(len/2, 0, gate);
        gmake(len / 2 - 1, 0, gate);
        var sen = Instantiate<GameObject>(sensor, transform);
        sen.transform.localPosition = new Vector3(len / 2, 1.5f, 0);
        sen.transform.Rotate(0, 0, 90);
    }

    public void removeMonster()
    {
        cnt--;
    }
    public void monsterSplit()
    {
        cnt++;
    }
}

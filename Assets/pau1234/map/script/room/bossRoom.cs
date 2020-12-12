using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossRoom : MonoBehaviour
{
    public int MAX_GRID;
    public TextAsset room;
    public GameObject[] block;
    public GameObject boss;
    public GameObject treasure;
    public GameObject transformGate;
    public GameObject sensor;
    public GameObject gate;

    struct node
    {
        public int x, y;
    };

    GameObject[,] gmap;

    int len, wid;

    GameObject gmake(int x, int y, GameObject g, int layer = 0)
    {
        var gtmp = Instantiate<GameObject>(g, transform);
        gtmp.transform.localPosition = new Vector3(x, y, layer);
        return gtmp;
    }
    // Use this for initialization
    void Awake()
    {
        Df = Uf = Rf = Lf = false;

        int[] input2 = myMethod.get_arr(room.ToString());
        len = input2[0];
        wid = input2[1];
        transform.localPosition = new Vector3(MAX_GRID / 2 - len / 2, MAX_GRID / 2 - wid / 2, 0);

        gmap = new GameObject[len, wid];
        for (int i = 0, k = 2; i < wid; i++)
        {
            for (int j = 0; j < len; j++, k++)
            {
                if (input2[k] == 0)
                {
                    continue;
                }
                gmap[j, wid - i - 1] = gmake(j, wid - i - 1, block[input2[k]]);
            }
        }
        GameObject backfloor = gmake(len / 2, wid / 2, block[0]);
        backfloor.GetComponent<SpriteRenderer>().size = new Vector2(len - 2, wid - 2);

        cnt = 1;
        gmake(len / 2, wid / 2, boss);
    }

    int cnt;
    // Update is called once per frame
    void Update()
    {
        if (tag == "start" && cnt <= 0)
        {
            tag = "finish";
            myMethod.gmake(len / 2, wid / 2 - 2, treasure, transform);
            myMethod.gmake(len / 2, wid / 2, transformGate, transform);
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
        Destroy(gmap[len / 2 + 1, wid - 1]);
        Destroy(gmap[len / 2, wid - 1]);
        Destroy(gmap[len / 2 - 1, wid - 1]);
        gmake(len / 2 + 1, wid - 1, gate);
        gmake(len / 2, wid - 1, gate);
        gmake(len / 2 - 1, wid - 1, gate);
        var sen = Instantiate<GameObject>(sensor, transform);
        sen.transform.localPosition = new Vector3(len / 2, wid - 2.5f, 0);
        sen.transform.Rotate(0, 0, 90);
    }
    bool Df;
    public void gateD()
    {
        if (Df) return;
        Df = true;
        Destroy(gmap[len / 2 + 1, 0]);
        Destroy(gmap[len / 2, 0]);
        Destroy(gmap[len / 2 - 1, 0]);
        gmake(len / 2 + 1, 0, gate);
        gmake(len / 2, 0, gate);
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

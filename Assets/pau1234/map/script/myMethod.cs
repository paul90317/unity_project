using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myMethod : MonoBehaviour {

    static public int[] get_arr(string str)
    {
        char[] ignore = new char[] { ' ', '\r', '\n' };
        string[] strs = str.Split(ignore);
        int[] arr = new int[strs.Length];
        int i = 0;
        for (int j = 0; j < strs.Length; j++)
        {
            if (strs[j].Length > 0)
            {
                arr[i++] = int.Parse(strs[j]);
            }
        }
        System.Array.Resize(ref arr, i);
        return arr;
    }

    static public GameObject gmake(int x, int y, GameObject g, Transform transform)
    {
        var gtmp = Instantiate<GameObject>(g, transform);
        gtmp.transform.localPosition = new Vector3(x, y, 0);
        return gtmp;
    }

    static public int round(float f)
    {
        int i = (int)f;

        if (f - (float)i > 0.9f)
        {
            return i + 1;
        }
        else return i;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageAmplify : MonoBehaviour {
    public int maxLevel;
    private int _LVL;
    private void Awake()
    {
        setLevel(0);
    }
    public int level
    {
        get { return _LVL; }
        set
        {
            _LVL = value > maxLevel ? maxLevel : value;
            setLevel(level);
        }
    }
    private void setLevel(int level)
    {
        switch (level)
        {
            default:
                break;
        }
    }
}

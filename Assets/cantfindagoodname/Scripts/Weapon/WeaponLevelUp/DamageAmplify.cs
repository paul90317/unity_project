using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageAmplify : MonoBehaviour {
    public int maxLevel;
    private int _LVL;
    private void Awake()
    {
        StartCoroutine(Start());
    }
    IEnumerator Start()
    {
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < GameObject.FindGameObjectWithTag("GameController").GetComponentInChildren<WeaponList>().weapons.Count; ++i)
            GameObject.FindGameObjectWithTag("GameController").GetComponentInChildren<WeaponList>().weapons[i].currentLevel = 0;
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
        GameObject.FindObjectOfType<Inventory>().inventory[GameObject.FindObjectOfType<Inventory>().current].currentLevel = level;
        switch (level)
        {
            default:
                break;
        }
    }
}

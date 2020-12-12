using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newHotWeapon", menuName = "Weapon/HotWeapon")]
public class HotWeapon : Weapon {
    public float firePoint;
    public int coolDown;
    public GameObject bullet;
    int cnt = 0;
    
    public override void cool()
    {
        if (cnt >= coolDown)
        {
            return;
        }
        cnt++;
    }
    public override void fire(Vector3 init, Vector3 dir)
    {
        if (cnt < coolDown)
        {
            return;
        }
        GameObject b = Instantiate<GameObject>(bullet);
        b.transform.right = dir;
        b.transform.position = init + b.transform.right * firePoint;
        cnt = 0;
    }
}

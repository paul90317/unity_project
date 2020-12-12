using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : ScriptableObject {

    public Sprite picture;
    public Vector2 size;
    public float handDistance;
    public virtual void fire(Vector3 init, Vector3 dir)
    {

    }
    public virtual void cool()
    {

    }
}

using System;
using UnityEngine;

public class MeleeArea : MonoBehaviour
{
    [NonSerialized]
    public int damage;

    public void Init(int damage, float lifetime)
    {
        this.damage = damage;
        Destroy(gameObject, lifetime);
    }
}

using System;
using UnityEngine;

public class CircularArea : MonoBehaviour
{
    [NonSerialized]
    public int damage;
    [NonSerialized]
    public float radius;
    [NonSerialized]
    public float effectDuration;
    
    public void Init(int damage, float lifetime, float radius, float effectDuration)
    {
        gameObject.transform.localScale = new Vector3(radius, radius, 1.0f);
        this.damage = damage;
        this.effectDuration = effectDuration;
        Destroy(gameObject, lifetime);
    }
}

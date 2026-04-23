using System;
using UnityEngine;

public class Pellet : MonoBehaviour
{
    [NonSerialized]
    public int damage;
    private Rigidbody2D rb2d;

    void Awake()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemigo"))
            Destroy(gameObject);
    }

    public void Init(int damage, float lifetime, float speed, Vector2 direction)
    {
        this.damage = damage;

        rb2d.linearVelocity = direction * speed;

        Destroy(gameObject, lifetime);
    }
}

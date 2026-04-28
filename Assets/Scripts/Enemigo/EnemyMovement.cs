using System;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    [SerializeField]
    private Transform playerTransform;
    private Rigidbody2D rb2d;
    private Vector2 followDir = new Vector2(1.0f, 0.0f);
    [NonSerialized]
    public bool shouldStopMoving = false;

    void Awake()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (playerTransform)
            followDir = (playerTransform.position - transform.position).normalized;
    }

    void FixedUpdate()
    {
        if (!shouldStopMoving)
            rb2d.linearVelocity = followDir * speed;
        else
            rb2d.linearVelocity = new Vector2(0.0f, 0.0f);
    }

    public void Knockback(float strength)
    {
        rb2d.AddForce(rb2d.linearVelocity.normalized * -strength);
    }

    internal void ApllySlow(float slowFactor, float slowDuration)
    {
        throw new NotImplementedException();
    }
}

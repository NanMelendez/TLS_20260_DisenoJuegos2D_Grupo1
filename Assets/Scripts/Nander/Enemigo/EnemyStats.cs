using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [SerializeField]
    private int maxHealth;
    private int health;
    [SerializeField]
    private int damage;
    private EnemyMovement movement;

    void Awake()
    {
        maxHealth = Mathf.Max(maxHealth, 1);
        health = maxHealth;
        movement = gameObject.GetComponent<EnemyMovement>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("MeleeArea"))
        {
            int dmg = collision.gameObject.GetComponent<MeleeArea>().damage;
            TakeDamage(dmg);
            movement.Knockback(100);
            Debug.Log($"Salud enemigo: {health}");
        }
        if (collision.CompareTag("Pellet"))
        {
            int dmg = collision.gameObject.GetComponent<Pellet>().damage;
            TakeDamage(dmg);
            movement.Knockback(30);
            Debug.Log($"Salud enemigo: {health}");
        }
    }

    void Update()
    {
        if (health <= 0)
        {
            movement.shouldStopMoving = true;
            Destroy(gameObject, 0.5f);
        }
    }

    public void TakeDamage(int dmg)
    {
        health = Mathf.Clamp(health - dmg, 0, maxHealth);
    }

    public int Health
    {
        get { return health; }
    }

    public int Damage
    {
        get { return damage; }
    }
}

using UnityEngine;

public class Lig : MonoBehaviour
{
    public string spellName = "LightningBolt";
    public int daño = 5;
    public float velocidad = 6f;
    public float TiempoDeVida = 1.5f;
    public float AreaRadius = 3f;
    public LayerMask LayerEnemigo;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = transform.right * velocidad;
        Destroy(gameObject, TiempoDeVida);

        GetComponent<Ability>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemigo") || collision.CompareTag("Piso"))
        {
            Collider2D[] golpearEnemigos = Physics2D.OverlapCircleAll(transform.position, AreaRadius, LayerEnemigo);

            foreach (Collider2D enemigo in golpearEnemigos)
            {
                VidaEnemigo vidaEnemigo = enemigo.GetComponent<VidaEnemigo>();
                if (vidaEnemigo != null)
                {
                    vidaEnemigo.RecibirDaño(daño);
                    Debug.Log(spellName + "impacto en area.Daño:" + daño);
                }
            }
            Destroy(gameObject);
        }

    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, AreaRadius);
    }
}

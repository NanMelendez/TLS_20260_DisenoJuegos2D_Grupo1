using UnityEngine;

public class IceBolt : MonoBehaviour
{
    public string speelName = "IceBolt";
    public int daño = 4;
    public float velocidad = 4f;
    public float TiempoDeVida = 2.5f;
    public float SlowDuration = 1.5f;
    public float SlowFactor = 0.5f;

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
        if (collision.CompareTag("Enemigo"))
        {
            VidaEnemigo vidaEnemigo = collision.GetComponent<VidaEnemigo>();
            if (vidaEnemigo != null)
            {
                vidaEnemigo.RecibirDaño(daño);
                Debug.Log(speelName + "impacto con un enemigo" + daño);

                EnemyMovement MovimientoEnemigo = collision.GetComponent<EnemyMovement>();
                if (MovimientoEnemigo != null)
                {
                    MovimientoEnemigo.ApllySlow(SlowFactor, SlowDuration);
                }
            }
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Piso"))
        {
            Destroy(gameObject);
        }
    }
}

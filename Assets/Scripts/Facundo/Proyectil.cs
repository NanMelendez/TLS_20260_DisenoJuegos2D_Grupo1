using UnityEngine;

public class Proyectil : MonoBehaviour
{
    public float velocidad = 5f;
    public int daño = 1;
    public float TiempoDeVida = 2.5f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = transform.right * velocidad;
        Destroy(gameObject, TiempoDeVida);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Jugador"))
        {
            VidaJugador vidaJugador = collision.GetComponent<VidaJugador>();
            if(vidaJugador != null)
            {
                vidaJugador.RecibirDaño(daño);
            }
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Suelo"))
        {
            Destroy(gameObject);
        }
    }
}


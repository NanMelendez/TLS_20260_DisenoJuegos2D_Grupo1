using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public string spellName = "Fireball";
    public int daño = 4;
    public float velocidad = 3.5f;
    public float TiempoDeVida = 3f;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = transform.right * velocidad;
        Destroy(gameObject, TiempoDeVida);

        GetComponent<Ability>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemigo"))
        {
            VidaEnemigo vidaEnemigo = collision.GetComponent<VidaEnemigo>();
            if (vidaEnemigo != null)
            {
                vidaEnemigo.RecibirDaño(daño);
                Debug.Log(spellName + "impacto contra enemigo.Daño" + daño);
            }
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Piso"))
        {
            Destroy(gameObject);
        }
    }


}




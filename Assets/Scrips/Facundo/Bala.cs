using UnityEngine;

public class Bala : MonoBehaviour
{
    public int daño = 2;
    public float TiempoDeVida = 3f;

    private void Start()
    {
        Destroy(gameObject,TiempoDeVida);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemigo"))
        {
            VidaEnemigo vidaEnemigo = collision.GetComponent<VidaEnemigo>();
            if(vidaEnemigo != null)
            {
                vidaEnemigo.RecibirDaño(daño);
            }
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Piso"))
        {
            Destroy(gameObject);
        }
    }
}

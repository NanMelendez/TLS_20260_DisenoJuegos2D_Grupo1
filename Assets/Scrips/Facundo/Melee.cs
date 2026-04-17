using UnityEngine;

public class Melee : MonoBehaviour
{
    public float velocidad = 4f;
    public float RangoDeAtaque = 1f;
    public int Daño = 1;
    private Transform jugador;

    private void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Jugador").transform;
        jugador.GetComponent<VidaJugador>();
    }

    private void Update()
    {
        if (jugador != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, jugador.position, velocidad * Time.deltaTime);

            float Distancia = Vector2.Distance(transform.position, jugador.position);
            if(Distancia <= RangoDeAtaque)
            {
                Ataque();
            }
        }
    }
    void Ataque()
    {
        VidaJugador vidaJugador = jugador.GetComponent<VidaJugador>();
        if( vidaJugador != null)
        {
            vidaJugador.RecibirDaño(Daño);
            Debug.Log("Ataque de enemigo melee causo! Daño" + Daño);
        }
        
    }
}

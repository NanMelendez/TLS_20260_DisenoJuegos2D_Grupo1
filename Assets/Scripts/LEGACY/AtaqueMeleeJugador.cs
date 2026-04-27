using UnityEngine;

public class AtaqueMeleeJugador : MonoBehaviour
{
    public int daño = 3;
    public float RangoDeAtaque = 2f;
    public Transform PuntoDeAtaque;
    public LayerMask CapaEnemigo;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Atacar();
        }
    }

    void Atacar()
    {
        Collider2D[] golpearEnemigos = Physics2D.OverlapCircleAll(PuntoDeAtaque.position, RangoDeAtaque, CapaEnemigo);

        foreach(Collider2D enemigo  in golpearEnemigos)
        {
            VidaEnemigo vidaEnemigo = enemigo.GetComponent<VidaEnemigo>();
            if(vidaEnemigo != null)
            {
                vidaEnemigo.RecibirDaño(daño);
                Debug.Log("Jugador golpeo a enemigo:" + daño);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
     if(PuntoDeAtaque == null) return;
        Gizmos.DrawWireSphere(PuntoDeAtaque.position, RangoDeAtaque);
    }
}

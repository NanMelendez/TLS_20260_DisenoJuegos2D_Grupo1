using UnityEngine;

public class VidaJugador : MonoBehaviour
{
    public int MaximaVida = 10;
    private int VidaActual;

    private void Start()
    {
        VidaActual = MaximaVida;
    }

    public void RecibirDaño(int cantidad)
    {
        VidaActual -= cantidad;
        Debug.Log("El jugador recibio daño. Vida actual" + VidaActual);

        if(VidaActual <= 0)
        {
            Muerto();
        }
    }
    void Muerto()
    {
        Debug.Log("El jugador fue derrotado");
    }
}

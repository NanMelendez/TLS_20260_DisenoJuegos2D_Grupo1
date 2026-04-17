using UnityEngine;

public class VidaEnemigo : MonoBehaviour
{
    public int VidaMaxima = 5;
    private int VidaActual;


    private void Start()
    {
        VidaActual = VidaMaxima;
    }

    public void RecibirDaño(int cantidad)
    {
        VidaActual -= cantidad;
        Debug.Log("El enemigo sufrio daño:" + VidaActual);

        if(VidaActual <= 0)
        {
            Muerto();
        }
    }
    void Muerto()
    {
        Debug.Log("Enemigo derrotado");


        Destroy(gameObject);
    }
}

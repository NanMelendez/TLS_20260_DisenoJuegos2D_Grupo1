using UnityEngine;

public class Thower : MonoBehaviour
{
    public GameObject proyectilPrefab;
    public Transform PuntoDeFuego;
    public float DañoxDisparo = 3f;
    private float TiempoxDisparo = 1f;

   

    private void Update()
    {
        if(Time.time > TiempoxDisparo)
        {
            Disparar();
            TiempoxDisparo = Time.time + DañoxDisparo;
        }
    }

    void Disparar()
    {
        Instantiate(proyectilPrefab, PuntoDeFuego.position, PuntoDeFuego.rotation);
    }
}

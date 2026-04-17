using UnityEngine;

public class AtaqueADistancia : MonoBehaviour
{
    public GameObject proyectilPrefab;
    public Transform PuntoDeDisparo;
    public float VelocidadDeBala = 10f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            Disparar();
        }
    }
    void Disparar()
    {
        GameObject bala = Instantiate(proyectilPrefab, PuntoDeDisparo.position, PuntoDeDisparo.rotation);
        Rigidbody2D rb = bala.GetComponent<Rigidbody2D>();
        rb.linearVelocity = PuntoDeDisparo.right * VelocidadDeBala;
    }
}

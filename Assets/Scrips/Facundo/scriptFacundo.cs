using JetBrains.Annotations;
using UnityEngine;

public class scriptFacundo : MonoBehaviour
{

    public float velocidad = 6f;
    public float FuerzaDeSalto = 5f;
    private Rigidbody2D rb;
    private bool EstaEnSuelo;
    
    void Start()
    {
      rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        //Movimiento Horizontal
        float movimiento = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(movimiento * velocidad, rb.linearVelocity.y);

        // Salto
        if(Input.GetButtonDown("Salto") && EstaEnSuelo)
        {
            rb.AddForce(Vector2.up * FuerzaDeSalto, ForceMode2D.Impulse);

            //Detección de Suelo

            void OnCollisionEnter2D(Collision collision)
            {
                if (collision.gameObject.CompareTag("Suelo"))
                {
                    EstaEnSuelo = true;
                }
            }
            void OnCollisionExit2D(Collision collision)
            {
                if (collision.gameObject.CompareTag("Suelo"))
                {
                    EstaEnSuelo = false;
                }
            }
        }
    }
}

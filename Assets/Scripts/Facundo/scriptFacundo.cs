
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
        float movimiento = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * movimiento * velocidad * Time.deltaTime);

        //Salto
        if(Input.GetButtonDown("Jump") && EstaEnSuelo)
        {
            rb.AddForce(Vector2.up * FuerzaDeSalto, ForceMode2D.Impulse);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Suelo"))
            EstaEnSuelo = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
            EstaEnSuelo = false;
    }
}

using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movimiento : MonoBehaviour
{
    public float speed;
    [SerializeField]
    private Rigidbody2D rb2d;

    private Vector2 dirMovement;
    private Vector2 lastDirection;
    private InputActionReference inputMovement;

    // Importante: ¡Crear la referencia al InputAction aquí!
    void Awake()
    {
        inputMovement = InputActionReference.Create(InputSystem.actions.FindActionMap("Jugador").FindAction("Mover"));
        lastDirection = new Vector2(1.0f, 0.0f); // Por defecto el jugador apunta a la derecha
    }

    // Importante: ¡Siempre activar dicha referencia aquí!
    void OnEnable()
    {
        inputMovement.action.Enable();
    }

    // Importante: ¡Siempre desactivar dicha referencia aquí!
    void OnDisable()
    {
        inputMovement.action.Disable();
    }
    
    void Update()
    {
        dirMovement = inputMovement.action.ReadValue<Vector2>();
        if (dirMovement.magnitude != 0.0)
            lastDirection = dirMovement;
    }

    void FixedUpdate()
    {
        rb2d.linearVelocity = dirMovement * speed;
    }
}

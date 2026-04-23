using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    [SerializeField]
    private Rigidbody2D rb2d;
    [SerializeField]
    private InputActionReference inputMovement;
    private Vector2 dirMovement;
    private Vector2 lastDirection;

    // Importante: ¡Crear la referencia al InputAction aquí!
    void Awake()
    {
        lastDirection = new Vector2(0.0f, -1.0f); // Por defecto el jugador apunta abajo
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

    public Vector2 LastDirection
    {
        get { return lastDirection; }
    }
}

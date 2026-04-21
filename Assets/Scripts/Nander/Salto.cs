using UnityEngine;
using UnityEngine.InputSystem;

public class Salto : MonoBehaviour
{
    public float jumpStrength;
    [SerializeField]
    private Rigidbody2D rb2d;
    [SerializeField]
    private SpriteRenderer playerSprite;
    [SerializeField]
    private Transform playerSpriteTransform;
    [SerializeField]
    private Transform transformShadow;
    private InputActionReference inputJump;
    private bool isJumpHeld;

    void Awake()
    {
        inputJump = InputActionReference.Create(InputSystem.actions.FindActionMap("Jugador").FindAction("Saltar"));
    }

    void OnEnable()
    {
        inputJump.action.Enable();
    }

    void OnDisable()
    {
        inputJump.action.Disable();
    }

    void Update()
    {
        isJumpHeld = inputJump.action.IsPressed();

        if (isJumpHeld)
            Debug.Log("¡Presionado!");
    }
}

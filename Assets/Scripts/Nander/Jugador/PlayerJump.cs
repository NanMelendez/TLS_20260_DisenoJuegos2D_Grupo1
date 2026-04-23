using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJump : MonoBehaviour
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
    [SerializeField]
    private InputActionReference inputJump;
    private bool isJumpHeld;

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

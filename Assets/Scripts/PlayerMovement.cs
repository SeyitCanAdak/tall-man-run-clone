using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private delegate void PlayerMovementDelegate();

    private PlayerMovementDelegate movement;

    [SerializeField] private bool isRigidbody;
    private PlayerControls playerInput;
    private CharacterController controller;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float playerSpeed = 2.0f;
    [SerializeField] private float gravityValue = -9.81f;
    [SerializeField] private PlayerAnimator playerAnimator;
    private Vector3 camForward, camRight;
    [SerializeField] private Camera Pcamera;

    public bool canMove;


    private Vector3 move;
    public float speedMagnitude => move.magnitude;

    public float vSpeed;
    
    private void Awake()
    {
        canMove = true;
        playerInput = new PlayerControls();
        controller = GetComponent<CharacterController>();

        if (isRigidbody)
        {
            controller.enabled = false;
            if (rb == null)
            {
                rb = gameObject.AddComponent<Rigidbody>();
                rb.constraints = RigidbodyConstraints.FreezeRotation;
                rb.mass = 100;
            }
            movement = PlayerMovementRigidbody;
        }
        else
        {
            Destroy(rb);
            rb = null;
            movement = PlayerMovementCharacterController;
        }
    }


    private void OnEnable()
    {
        playerInput.Enable();
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }

    private void FixedUpdate()
    {
        Vector2 movementInput = playerInput.Player.Move.ReadValue<Vector2>();
        
        var transform1 = Pcamera.transform;
        camForward = transform1.forward;
        camRight = transform1.right;
        camForward.y = 0;
        camRight.y = 0;
        camForward = camForward.normalized;
        camRight = camRight.normalized;
        
        move = movementInput.x * camRight + Mathf.Clamp(movementInput.y,0,1) * camForward;
        //move = new Vector3(movementInput.x, 0f, movementInput.y);
        if (canMove)
        {
            movement();
        }

        playerAnimator.SetSpeed(move.magnitude);
        
        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }
    }

    private void PlayerMovementRigidbody()
    {
        rb.MovePosition(transform.position + move * playerSpeed * Time.fixedDeltaTime);
    }

    private void PlayerMovementCharacterController()
    {
        controller.Move(move * Time.deltaTime * playerSpeed);
        if (!controller.isGrounded) // add free fall
        {
            controller.SimpleMove(Vector3.forward * 0);
        }
    }
}
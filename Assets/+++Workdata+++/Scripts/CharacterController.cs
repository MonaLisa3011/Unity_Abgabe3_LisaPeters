using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterControllerSide : MonoBehaviour
{
    private float direction = 0f;
    [SerializeField] private float speed = 2f;
    [SerializeField] private float jumpforce = 10f;


    private Rigidbody2D rb;

    [Header("Ground Check")] [SerializeField]
    private Transform transformGroundCheck;

    [SerializeField] private LayerMask layerGround;


    private bool canMove = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(rb.linearVelocity);

        direction = 0;


        if (Keyboard.current.aKey.isPressed)
        {
            direction = -1;
        }

        if (Keyboard.current.dKey.isPressed)
        {
            direction = 1;
        }

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Jump();
        }

        rb.linearVelocity = new Vector2(direction * speed, rb.linearVelocity.y);
    }

    void Jump()
    {
        if (Physics2D.OverlapCircle(transformGroundCheck.position, 0.3f, layerGround))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x,jumpforce);
        }
    }
}


using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterControllerSide : MonoBehaviour
{
    private float direction = 0f;
    [SerializeField] private float speed = 3f;
    [SerializeField] private float jumpforce = 7f;

    private Rigidbody2D rb;

    [Header("Ground Check")] [SerializeField]
    private Transform transformGroundCheck;
    
    [Header ("Manager")] [SerializeField] private CoinManager coinManager;
    [SerializeField] private UIManager uiManager;

    [SerializeField] private LayerMask layerGround;
    
    [SerializeField] GameObject VerlorenPanel;

    [SerializeField] private TextMeshProUGUI textCoinCount;


    private bool canMove = true;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        canMove = true;
        
        VerlorenPanel.SetActive(false);
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
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpforce);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            coinManager.AddCoin();
            Destroy(other.gameObject);
        }

        else if (other.CompareTag("Feind"))
        {
            VerlorenPanel.SetActive(true);
            canMove = false;
        }
    }
}


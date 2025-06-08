using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterControllerSide : MonoBehaviour
{
    // die direction steht auf 0
    private float direction = 0f;
    // die Angaben fürs Springen und für die Geschwindigkeit 
    [SerializeField] private float speed = 3f;
    [SerializeField] private float jumpforce = 7f;

    // es ist ein Rigidbody
    private Rigidbody2D rb;
    
    // für die Audio
    AudioSource audioSource;

    //für die Benutzung des Groundchecks
    [Header("Ground Check")] [SerializeField]
    private Transform transformGroundCheck;
    
    // du kannst die anderen Scripts benutzen
    [Header ("Manager")] [SerializeField] private CoinManager coinManager;
    [SerializeField] private UIManager uiManager;

    // du kannst die layerground benutzen
    [SerializeField] private LayerMask layerGround;
    
    // du kannst die Panels benutzen
    [SerializeField] GameObject VerlorenPanel;
    [SerializeField] GameObject GewonnenPanel;

    // du kannst das TextMeshPro benutzen für den textCoinCount
    [SerializeField] private TextMeshProUGUI textCoinCount;


    // du kannst dich bewegen
    private bool canMove = true;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Komponenten abrufen 
        rb = GetComponent<Rigidbody2D>();

        // du kannst dich bewegen
        canMove = true;
        
        // wenn das Spiel startet sollen diese Panels nicht angezeigt werden
        VerlorenPanel.SetActive(false);
        GewonnenPanel.SetActive(false);
        
        // die Audio soll dann funktionieren 
        audioSource = GetComponent<AudioSource>();
    }

    

    // Update is called once per frame
    void Update()
    {
        // der CountdownManager startet wenn das Spiel beginnt
        if(FindObjectOfType<CountdownManager>().gameStarted == true)
        {
            Debug.Log(rb.linearVelocity);

            //du fängst bei 0 an
            direction = 0;


            //wenn man a tippt soll der Charakter nach links
            if (Keyboard.current.aKey.isPressed)
            {
                direction = -1;
            }

            //wenn man d tippt soll der Charakter nach rechts
            if (Keyboard.current.dKey.isPressed)
            {
                direction = 1;
            }

            //wenn man die Leertaste tippt soll der Charakter springen
            if (Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                Jump();
            }

            //die lineare Geschwindigkeit 
            rb.linearVelocity = new Vector2(direction * speed, rb.linearVelocity.y); 
        }
       
    }

    // Thema springen
    void Jump()
    {
        // er soll auf den Groundcheck beim springen achten 
        if (Physics2D.OverlapCircle(transformGroundCheck.position, 0.3f, layerGround))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpforce);
        }
    }

    // wenn ein Collider2D auf etwas drauf ist soll das geschehen 
    private void OnTriggerEnter2D(Collider2D other)
    {
        // wenn du einen Coin berührst soll das passieren
        if (other.CompareTag("Coin"))
        {
            // es soll Ton kommen wenn du einen Coin berührst
            audioSource.Play();
            // es soll ein Coin zum CoinManager zugerechnet werden 
            coinManager.AddCoin();
            // der Coin soll verschwinden wenn wir ihn berühren 
            Destroy(other.gameObject);
        }

        // wenn du einen Feind berührst kommt das Verloren Panel
        else if (other.CompareTag("Feind"))
        {
            VerlorenPanel.SetActive(true);
            // wenn das Verloren Panel erscheint kann der Spieler sich nicht mehr bewegen
            canMove = false;
        }
        
        // wenn du die Scheune berührst kommt das Gewonnen Panel
        else if (other.CompareTag("Scheune"))
        {
            GewonnenPanel.SetActive(true);
            // wenn das Gewonnen Panel erscheint kann der Spieler sich nicht mehr bewegen 
            canMove = false;
        }
    }
}


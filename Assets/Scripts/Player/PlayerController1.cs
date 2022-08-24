using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController1 : MonoBehaviour {

    [HideInInspector] public Rigidbody2D rigidBody;

    public float moveSpeed;

    //Make instance of this script to be able reference from other scripts! (gracias Brackeys!)
    [HideInInspector] public static PlayerController instance;

    [HideInInspector] public bool canMove = true;   // No se usa

    private float h;
    private float v;
    private float f;

    public float horizontalSpeed;
    public float verticalStrength;

    private bool isJumping;
    public bool isDead;

    private bool isShooting;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        isJumping = false;
        isDead = false;
        isShooting = false;
    }

    private void LateUpdate() 
    {
        if (!isDead)    
        {
            h = Input.GetAxisRaw("Horizontal") * horizontalSpeed * Time.deltaTime;
            v = Input.GetAxisRaw("Jump");

            this.gameObject.transform.Translate(h, 0.0f, 0.0f);

            if (h > 0.001f)
            {
                gameObject.transform.GetComponent<SpriteRenderer>().flipX = false;
            }
            else if (h < -0.001f)
            {
                gameObject.transform.GetComponent<SpriteRenderer>().flipX = true;
            }

            if (!isJumping)
            {
                if (v > 0)
                {
                    this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, verticalStrength);

                    isJumping = true;
                }
            }
        }

        // add dieing condition for player y isDead = true
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor") isJumping = false;
    }
}

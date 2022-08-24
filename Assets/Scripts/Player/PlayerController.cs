using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {

    [HideInInspector]
    public Rigidbody2D rigidBody;
    [HideInInspector]
    public Animator animator;
    public float moveSpeed;
    
    //Make instance of this script to be able reference from other scripts!
    public static PlayerController instance;

    [HideInInspector]
    public string areaTransitionName;
    private Vector3 boundary1;
    private Vector3 boundary2;

    [HideInInspector]
    public bool canMove = true;

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
        animator = GetComponent<Animator>();
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
                animator.SetFloat("lastMoveX", h);
            }
            else if (h < -0.001f)
			{
                gameObject.transform.GetComponent<SpriteRenderer>().flipX = true;
                animator.SetFloat("lastMoveX", h);
            }
            animator.SetFloat("moveX", h);

            if (!isJumping) //  Si no está saltando, puede saltar 
            {
                if (v > 0)
                {
                    //this.gameObject.transform.GetChild(0).GetComponent<Animator>().SetInteger("statePlayer2D", 2);  // salto 
                    animator.SetTrigger("jump");
                    this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, verticalStrength); // aplico fuerza
                    isJumping = true;
                    if (isJumping)
                    {
                        if (isJumping != null)
                        {
                            //jumpSound.GetComponent<AudioSource>().Play();
                        }
                    }

                }
            }
        }
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
        if (collision.gameObject.tag == "Floor")
        {
            isJumping = false;
        }
    }

	/*
        // Use this for initialization
        void Awake () {

        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        if (instance == null)
        {
            instance = this;
        } else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }

        DontDestroyOnLoad(gameObject);
	}

    ///*
    // MOBILE INPUT
    // Uncomment this complete Update() function to enable mobile controls. But comment out the whole Update() function below this one.
    // Update is called once per frame
    void Update () {
        if (ControlManager.instance.mobile)
        {
            if (canMove)
            {
                rigidBody.velocity = new Vector2(Mathf.RoundToInt(CrossPlatformInputManager.GetAxis("Horizontal")), Mathf.RoundToInt(CrossPlatformInputManager.GetAxis("Vertical"))) * moveSpeed;
            }
            else
            {
                rigidBody.velocity = Vector2.zero;

            }

            animator.SetFloat("moveX", rigidBody.velocity.x);
            animator.SetFloat("moveY", rigidBody.velocity.y);

            if (CrossPlatformInputManager.GetAxisRaw("Horizontal") == 1 || CrossPlatformInputManager.GetAxisRaw("Horizontal") == -1 || CrossPlatformInputManager.GetAxisRaw("Vertical") == 1 || CrossPlatformInputManager.GetAxisRaw("Vertical") == -1)
            {
                if (canMove)
                {
                    animator.SetFloat("lastMoveX", CrossPlatformInputManager.GetAxisRaw("Horizontal"));
                    animator.SetFloat("lastMoveY", CrossPlatformInputManager.GetAxisRaw("Vertical"));
                }
            }

            transform.position = new Vector3(Mathf.Clamp(transform.position.x, boundary1.x, boundary2.x), Mathf.Clamp(transform.position.y, boundary1.y, boundary2.y), transform.position.z);
        }

        if (!ControlManager.instance.mobile)
        {
            if (canMove)
            {
                rigidBody.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
                rigidBody.velocity = rigidBody.velocity.normalized * moveSpeed;
            }
            else
            {
                rigidBody.velocity = Vector2.zero;

            }

            animator.SetFloat("moveX", rigidBody.velocity.x);
            animator.SetFloat("moveY", rigidBody.velocity.y);

            if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
            {
                if (canMove)
                {
                    animator.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal"));
                    animator.SetFloat("lastMoveY", Input.GetAxisRaw("Vertical"));
                }
            }

            //This calculates the bounds and doesn't let the player go beyond the defined bounds
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, boundary1.x, boundary2.x), Mathf.Clamp(transform.position.y, boundary1.y, boundary2.y), transform.position.z);
        }
        
    }

    //Method to set up the bounds which the player can not cross
    public void SetBounds(Vector3 bound1, Vector3 bound2)
    {
        boundary1 = bound1 + new Vector3(.5f, 1f, 0f);
        boundary2 = bound2 + new Vector3(-.5f, -1f, 0f);
    }
    */
}
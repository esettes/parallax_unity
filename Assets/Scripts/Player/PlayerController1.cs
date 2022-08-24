using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController1 : MonoBehaviour {

    [HideInInspector] public Rigidbody2D rigidBody; // H.I.I permite almacenar la modific. del
    // obj o var en tiempo de ejecución tras Stop, de otro modo, al salir de la ejec., la var
    // recupera su valor original antes de ejecutar Play

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

    private void Awake() // Ejecuta código antes del primer frame 
    {
        rigidBody = GetComponent<Rigidbody2D>(); // Inicializa la var asignada en el inspector
    }

    void Start() // Primer frame, ejecuta codigo
    {
        isJumping = false;
        isDead = false; // Realmente no se usa
        isShooting = false; // Tampoco este
    }

    private void LateUpdate() // similar a Update() (Upd. se ejecuta 1 vez por cada frame)
    // LateUpdate se ejecuta después de cada ejecución de Update(), LU() es recomendable para
    // controlar el mov. de la cámara y evitar cortes de imagen
    // FixedUpdate() se ejecuta una o varias veces antes de 1 sola ejecución de Update()
    // https://docs.unity3d.com/ScriptReference/MonoBehaviour.FixedUpdate.html 
    {
        if (!isDead)    // si no está muerto
        {
            // Axis que controlan inputs, configurables en Edit> Project settings> Input manager
            h = Input.GetAxisRaw("Horizontal") * horizontalSpeed * Time.deltaTime;
            v = Input.GetAxisRaw("Jump");


            this.gameObject.transform.Translate(h, 0.0f, 0.0f); // Aplicar en el eje X


            // Mayor a cero se mueve a un lado, y menor hacia el otro
            if (h > 0.001f)
            {
                gameObject.transform.GetComponent<SpriteRenderer>().flipX = false;
            }
            else if (h < -0.001f)
            {
                //  Invierte eje x del sprite player si la fuerza se aplica al otro lado
                gameObject.transform.GetComponent<SpriteRenderer>().flipX = true;
            }


            if (!isJumping) //  Si no está saltando, puede saltar 
            {
                if (v > 0)
                {
                    this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, verticalStrength); // aplico fuerza

                    isJumping = true; // Estoy saltando, por lo que no puedo saltar más
                }
            }
        }

        // Añadir condición de muerte de player y isDead = true
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //  Cuando objetos con Coll.2D y etiquetas Floor y Player están chocando, se invoca el evento
        // Para que esto funcione correctamente, a parte de Coll.2D al menos 1 de los dos obj debe tener un rigidbody2D (cuidado con poner variables 3D a obj. 2D, esto no funcionara
        if (collision.gameObject.tag == "Floor") isJumping = false;
    }
}
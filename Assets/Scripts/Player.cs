
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [Header("Movimiento")]
    [SerializeField] int velocidadMovimiento;
    [SerializeField] private float velocidad;
    [SerializeField] private float factorGravedad;
    [SerializeField] private float alturaSalto;

    [Header("Detección suelo")]
    [SerializeField] private float radioDeteccion;
    [SerializeField] private Transform pies;
    [SerializeField] private LayerMask queEsSuelo;


    [SerializeField] private float vidasActuales;
    //[SerializeField] private float vidasMax;
    //[SerializeField] TMP_Text textVidas;
    [SerializeField] private int puntosComida;
    [SerializeField] TMP_Text textPuntuacion;

    [SerializeField] private GameObject weaponHolder;
    [SerializeField] private GameObject menuGameOver;
    [SerializeField] private GameObject menuPausa;

    private Camera cam;

    private CharacterController controller;

    //me sirve tanto para la gravedad como 
    private Vector3 movimientoVertical;

    public int PuntosComida { get => puntosComida; set => puntosComida = value; }

    //public float VidasActuales { get => vidasActuales; set => vidasActuales = value; }
    //public float VidasMax { get => vidasMax; set => vidasMax = value; }

    private void FixedUpdate()
    {
        MenuPausa();
    }

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();

        //Bloquea el ratón en centro 
        Cursor.lockState = CursorLockMode.Locked;
        cam = Camera.main;
        

    }

    // Update is called once per frame
    void Update()
    {
        MoveryRotar();
        AplicarGravedad();
     



        if (EnSuelo())
        {
            //Cada vez que aterricemos, cancelamos la gravedad
            movimientoVertical.y = 0;
            Saltar();
        }
    }

    private void Saltar()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Aplico "rórmula" de salto, para saltar la cantidad de altura que yo quiera.
            movimientoVertical.y = Mathf.Sqrt(-2 * factorGravedad * alturaSalto);

        }

    }

    private void MoveryRotar()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector2 input = new Vector2(h, v).normalized;

        //Roto el cuerpo de forma constante con la rotacion "y" de la cámara.
        transform.rotation= Quaternion.Euler(0,Camera.main.transform.eulerAngles.y,0);

        //Si el jugador ha tocado teclas...
        if (input.magnitude > 0)
        {
            //Calculo el angulo al que tengo que rotarme en funcion de los inputs y camara
            float angulo = Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;
            //transform.eulerAngles = new Vector3(0, angulo, 0);

            //mi movimiento también ha quedado rotado en base al angulo calculado
            Vector3 movimiento = Quaternion.Euler(0, angulo, 0) * Vector3.forward;

            controller.Move(movimiento * velocidadMovimiento * Time.deltaTime);



        }
       
    }
    private void MenuPausa()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
           
            weaponHolder.SetActive(false);
            menuPausa.SetActive(true);
           
            MoveryRotar();
            Time.timeScale = 0f;

        }
        else
        {
            weaponHolder.SetActive(true);
            Cursor.lockState = CursorLockMode.Locked;
            MoveryRotar();
        }
    }
    private void AplicarGravedad()
    {
        //Mi velocidadVertical va en aumento a cierto factor por segundo
        movimientoVertical.y += factorGravedad * Time.deltaTime;
        controller.Move(movimientoVertical * Time.deltaTime);
    }
    private bool EnSuelo()
    {
        //Tirar una esfera de detección en los pies con cierto radio.
        bool resultado= Physics.CheckSphere(pies.position,radioDeteccion,queEsSuelo);
        return resultado;
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coleccionable"))
        {
            puntosComida += 1;
            textPuntuacion.text = "POINT: " + puntosComida;
            Destroy(other.gameObject);

            if (puntosComida >= 5)
            {
                // Mostrar el menú de Game Over
                menuGameOver.SetActive(true);

                // Pausar el juego (opcional)
                Time.timeScale = 0f; // Detener el tiempo del juego
            }
        }

    
    }


    public void RecibirDanho(float danhoEnemigo)
    {
        //textVidas.text = "Vidas: "+vidasActuales + "/"+vidasMax;
        vidasActuales -= danhoEnemigo;
        if (vidasActuales <= 0)
        {
            Cursor.lockState = CursorLockMode.None;
            //Time.timeScale=0; //Para parar el tiempo
            menuGameOver.SetActive(true);
            Time.timeScale = 0f;
            Destroy(gameObject);
           

        }
        
    }


    //Método que se ejecuta automáticamente para dibujar cualquier figura
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(pies.position, radioDeteccion);
    }
    //private void GameOver()
    //{
    //    if(vidasActuales==0)
    //    {
    //        SceneManager.LoadScene(3);
    //    }
    //}
}

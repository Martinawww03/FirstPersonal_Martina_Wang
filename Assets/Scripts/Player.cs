using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movimiento")]
    [SerializeField] int velocidadMovimiento;
    [SerializeField] private float velocidad;
    [SerializeField] private float factorGravedad;
    [SerializeField] private float alturaSalto;

    [Header("Detecci�n suelo")]
    [SerializeField] private float radioDeteccion;
    [SerializeField] private Transform pies;
    [SerializeField] private LayerMask queEsSuelo;


    [SerializeField] private float vidas;

    private CharacterController controller;

    //me sirve tanto para la gravedad como 
    private Vector3 movimientoVertical;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();

        //Bloquea el rat�n en centro 

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
            //Aplico "r�rmula" de salto, para saltar la cantidad de altura que yo quiera.
            movimientoVertical.y = Mathf.Sqrt(-2 * factorGravedad * alturaSalto);

        }

    }

    private void MoveryRotar()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector2 input = new Vector2(h, v).normalized;

        //Roto el cuerpo de forma constante con la rotacion "y" de la c�mara.
        transform.rotation= Quaternion.Euler(0,Camera.main.transform.eulerAngles.y,0);

        //Si el jugador ha tocado teclas...
        if (input.magnitude > 0)
        {
            //Calculo el angulo al que tengo que rotarme en funcion de los inputs y camara
            float angulo = Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;
            //transform.eulerAngles = new Vector3(0, angulo, 0);

            //mi movimiento tambi�n ha quedado rotado en base al angulo calculado
            Vector3 movimiento = Quaternion.Euler(0, angulo, 0) * Vector3.forward;

            controller.Move(movimiento * velocidadMovimiento * Time.deltaTime);



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
        //Tirar una esfera de detecci�n en los pies con cierto radio.
        bool resultado= Physics.CheckSphere(pies.position,radioDeteccion,queEsSuelo);
        return resultado;
    }
    
    public void RecibirDanho(float danhoEnemigo)
    {
        vidas -= danhoEnemigo;
    }


    //M�todo que se ejecuta autom�ticamente para dibujar cualquier figura
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(pies.position, radioDeteccion);
    }
}

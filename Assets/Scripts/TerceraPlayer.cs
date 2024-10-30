using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerceraPlayer : MonoBehaviour
{
    private Animator anim; //Valor nulo
    [SerializeField] int velocidadMovimiento;
    [SerializeField] int smoothTime;
    private float rotacion;
    private CharacterController controller;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        GetComponent<Animator>();
        anim = GetComponent<Animator>(); //para dar el valor
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveryRotar();
    }

    private void MoveryRotar()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector2 input = new Vector2(h, v).normalized;

        //Si el jugador ha tocado teclas...
        if (input.magnitude > 0) //magnitude es el tamaño
        {

            //Calculo el angulo al que tengo que rotarme en funcion de los inputs y camara
            float angulo = Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;


            float anguloSuave = Mathf.SmoothDampAngle(transform.eulerAngles.y,angulo, ref rotacion, smoothTime);
            transform.eulerAngles = new Vector3(0, anguloSuave, 0);

            //mi movimiento también ha quedado rotado en base al angulo calculado
            Vector3 movimiento = Quaternion.Euler(0, angulo, 0) * Vector3.forward;

            controller.Move(movimiento * velocidadMovimiento * Time.deltaTime);

            anim.SetBool("walking", true);


        }
        else
        {
            anim.SetBool("walking", false);
        }
    }
}

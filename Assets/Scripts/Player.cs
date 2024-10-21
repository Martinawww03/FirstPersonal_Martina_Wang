using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] int velocidadMovimiento;
    private CharacterController controller;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector2 input= new Vector2(h, v).normalized;

        //Si el jugador ha tocado teclas...
        if(input.magnitude >0)
        {
            //Calculo el angulo al que tengo que rotarme en funcion de los inputs y camara
        float angulo = Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;
        transform.eulerAngles=new Vector3(0,angulo,0);

            //mi movimiento también ha quedado rotado en base al angulo calculado
            Vector3 movimiento = Quaternion.Euler(0, angulo, 0) * Vector3.forward;

            controller.Move(movimiento*velocidadMovimiento*Time.deltaTime);



        }
    }
}

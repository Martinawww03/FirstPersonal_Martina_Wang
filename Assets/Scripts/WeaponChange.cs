using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponChange : MonoBehaviour
{
    [SerializeField] private GameObject[] armas;

    //Recoge al indice de arma actual.
    private int indiceArmaActual; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CambiarArmaConTeclado();
        CambiarArmaConRaton();
    }
    private void CambiarArmaConRaton()
    {
        float scrollWheel = Input.GetAxis("Mouse ScrollWheel");
        if(scrollWheel >0) //
        {

        }
        else if (scrollWheel <0)
        {

        }
    }
    private void CambiarArmaConTeclado()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
        {
            CambiarArma(0);

        }
        if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
        {
            CambiarArma(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
        {
            CambiarArma(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4))
        {
            CambiarArma(3);
        }
    }

    private void CambiarArma(int indiceNuevaArma)
    {
        //Desactivo el arma actual
        //armas[indiceArmaAcual].SetActive(false);

        //Activar la nueva
        armas[indiceNuevaArma].SetActive(true); //con eso no vale, porque he activado la nueva, pero no he desactivado lo anterior

        //indiceArmaActual == indiceNuevaArma;
    }
}

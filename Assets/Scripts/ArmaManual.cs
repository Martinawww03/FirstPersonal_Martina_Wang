using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaManual : MonoBehaviour
{
    [SerializeField] private ArmaSO misDatos;
    [SerializeField] private ParticleSystem system;

    private Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main; //te da aceso al la camara etiquetadad como "Main Camar"
    }

    // Update is called once per frame
    void Update()
    {
      if(Input.GetMouseButtonDown(0))
        {
            system.Play(); //Ejecuto la particula
            if(Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hitInfo, misDatos.distanciaAtaque))
            {
               // Debug.Log(hitInfo.transform.name); //Muestro el nombre de a quien ha impactado
               if(hitInfo.transform.CompareTag("ParteEnemigo")) //Compare es mejor que tag
                {
                  hitInfo.transform.GetComponent<Enemigo>().RecibirDanho(misDatos.danhoAtaque);

                }

            }

        }   
    }
}

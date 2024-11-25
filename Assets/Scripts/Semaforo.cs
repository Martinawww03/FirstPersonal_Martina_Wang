using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Semaforo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(EjemploSemaforo()); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator EjemploSemaforo()
    {
        while(true)
        {
         Debug.Log("Verde");

         //Espera 2 segundos
         yield return new WaitForSeconds(2); //vuelve al código principal en Update

         Debug.Log("Amarillo");

        
         //Espera 4 segundos
         yield return new WaitForSeconds(4);
         Debug.Log("Rojo");

        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sandia : MonoBehaviour
{
    private Rigidbody rb;

    [Header("Explosion")]
    [SerializeField] private float fuerzaImpulso;
    [SerializeField] private float fuerzaExplosion;
    [SerializeField] private float radioExplosion;
    [SerializeField] private GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * fuerzaImpulso, ForceMode.Impulse);
        Destroy(gameObject, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    //Se ejecuta automaticamente cuando esta entidad (sandía) se va a morir
    private void OnDestroy()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        //if (Physics.OverlapSphereNonAlloc(transform.position, radioExplosion, buffer, queEsplotable) > 0) ;


        //Si el numero de detecciones es superior a 0....
        //if(numeroDetectados>0)
        //{
              //Recorrer  todos los colliders detectados....
        //    for(int i = 0; i<numeroDetectados; i++)
        //    {
        //        buffer[i].TryGetComponent(out ParteDeEnemigo scriptHueso))
        //    }
        //}
    }
}

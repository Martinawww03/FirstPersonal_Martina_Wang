using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sandia : MonoBehaviour
{
    private Rigidbody rb;

    [Header("Explosion")]
    [SerializeField] private float fuerzaImpulso;
    [SerializeField] private float tiempoVida;
    [SerializeField] private float radioExplosion;
    [SerializeField] private LayerMask queEsExplotable;
    [SerializeField] private GameObject explosionPrefab;
    [SerializeField] private float fuerzaExplosion;
    [SerializeField] private float rebote;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward.normalized * fuerzaImpulso, ForceMode.Impulse);
        Destroy(gameObject, tiempoVida);
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    //Se ejecuta automaticamente cuando esta entidad (sandía) se va a morir
    private void OnDestroy()
    {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Collider[] collsDetectados = Physics.OverlapSphere(transform.position, radioExplosion, queEsExplotable);
        if(collsDetectados.Length > 0)
        {
            foreach(Collider coll in collsDetectados)
            {
                coll.GetComponent<ParteDeEnemigo>().Explotar();
                coll.GetComponent<Rigidbody>().isKinematic = false;
                coll.GetComponent<Rigidbody>().AddExplosionForce(fuerzaExplosion, transform.position, radioExplosion,rebote,ForceMode.Impulse);

            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class SistemaInteracciones : MonoBehaviour
{
    private Camera cam;
    private Transform interactuableActual;
    [SerializeField] private float distanciaInteraccion;
    // Start is called before the first frame update
    void Start()
    {
        cam=Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void FixedUpdate() //Para aligerar recursos, lo meto en el fixed
    { 
        if(Physics.Raycast(cam.transform.position,cam.transform.forward, out RaycastHit hit,distanciaInteraccion))
    {
       if(hit.transform.TryGetComponent(out CajaMunicion cajaScript)) 
       {
          
       }
    }

    }


}

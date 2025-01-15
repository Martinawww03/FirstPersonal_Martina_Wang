using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaAutomatica : MonoBehaviour
{
    [SerializeField] private ParticleSystem system;
    [SerializeField] private ArmaSO misDatos;
    private Camera cam;
    private float timer;

    private void Start()
    {
        cam = Camera.main;

        timer = misDatos.cadenciaAtaque;
    }
    private void Update()
    {
        timer += Time.deltaTime;

        if(Input.GetMouseButton(0)&& timer >= misDatos.cadenciaAtaque)
        {
            system.Play();
            if(Physics.Raycast(cam.transform.position,cam.transform.forward,out RaycastHit hitInfo, misDatos.distanciaAtaque)) //Hace una raya hasta enfrente
            {
                if(hitInfo.transform.TryGetComponent(out ParteDeEnemigo scriptEnemigo))
                {
                    scriptEnemigo.RecibirDanno(misDatos.danhoAtaque);
                }
                //system.Play();
                //if(hit.transform.CompareTag("ParteEnemigo"))
                //{
                //    hit.transform.GetComponent<ParteDeEnemigo>().RecibirDanno(misDatos.distanciaAtaque);
                //}
            }
            timer = 0;
        }
    }
}

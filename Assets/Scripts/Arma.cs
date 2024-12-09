using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : MonoBehaviour
{
    [SerializeField]public Transform spawnPoint;
    
    [SerializeField]public GameObject bullet;
    
    [SerializeField]public int fuerzaDisparo = 1500;
    [SerializeField]public float velocidadDisparo = 0.5f;
    
    [SerializeField]private float shotRateTime = 0;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")) //fire 1= click izq del raton
        {
            if(Time.time > shotRateTime)
            {
             GameObject newBullet;
             newBullet = Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);

             newBullet.transform.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * fuerzaDisparo);

             shotRateTime = Time.time + velocidadDisparo;
             Destroy(newBullet, 5);

            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colecionable : MonoBehaviour
{
    //[SerializeField] private AudioClip sonidoClip;
    //[SerializeField] private AudioManager miManager;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(-40, 30, 0) * Time.deltaTime);
    }
   // private void OnTriggerEnter(Collider other)
   // {
   //     if (other.gameObject.CompareTag("Player"))
   //     {
   //         Destroy(other.gameObject);
   //         //miManager.ReproducirSonido(sonidoClip);
   //     }
   // }
}

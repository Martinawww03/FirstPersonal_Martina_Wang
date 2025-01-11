using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivadorDetector : MonoBehaviour
{
    [SerializeField] private GameObject spawneador;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            spawneador.SetActive(true);
        }
    }
}

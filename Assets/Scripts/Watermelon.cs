using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Watermelon : MonoBehaviour
{
    [SerializeField] private GameObject sandiaPrefab; 
    [SerializeField] private Transform spawnPoint; //boca del pistola
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            //Instanciar una copia del prefab sandía en la boca del pistola
            Instantiate(sandiaPrefab, spawnPoint.position, transform.rotation);
            Debug.Break();//se pausa unity


        }
    }
}

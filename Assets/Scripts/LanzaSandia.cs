using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanzaSandia : MonoBehaviour
{
    [SerializeField] private ParticleSystem system;
    [SerializeField] private GameObject sandiaPrefab;
    [SerializeField] private Transform sandiaSpawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            //system.Play();
            Instantiate(sandiaPrefab,sandiaSpawn.position,sandiaSpawn.rotation);
        }
    }
}

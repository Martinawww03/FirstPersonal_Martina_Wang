using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform[] puntoSpawn; //Array
    [SerializeField] private Enemigo enemigoPrefab; 

    private void Start()
    {
        StartCoroutine(SpawnEnemigos()); //espaunea cada 2 segundos en posiciones aleatoria.
    }
    IEnumerator SpawnEnemigos() //Corrutina
    {
        while (true)
        {
            Instantiate(enemigoPrefab, puntoSpawn[Random.Range(0, puntoSpawn.Length)].position, Quaternion.identity);
            yield return new WaitForSeconds(2);
        }
    }

}

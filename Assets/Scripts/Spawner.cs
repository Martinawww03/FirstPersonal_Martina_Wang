using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform[] puntoSpawn;
    [SerializeField] private Enemigo enemigoPrefab;

    private void Start()
    {
        StartCoroutine(SpawnEnemigos());
    }
    IEnumerator SpawnEnemigos()
    {
        while (true)
        {
            Instantiate(enemigoPrefab, puntoSpawn[Random.Range(0, puntoSpawn.Length)].position, Quaternion.identity);
        }
    }

}

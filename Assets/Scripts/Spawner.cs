using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject enemigoPrefab;
    [SerializeField] private Transform[] puntosSpawn;
    [SerializeField] private int numeroNiveles;
    [SerializeField] private int rondasporNivel;
    [SerializeField] private float spwansPorRonda;
    [SerializeField] private float esperaEntreSpawns;
    [SerializeField] private float esperaEntreRondas;
    [SerializeField] private float esperaEntreNiveles;

    // Start is called before the first frame update
    void Start()
    {
        
        //Sacar una copia del prefab del enemigo en una posición.
        //Quaternion.identity: Rotación(0,0,0)
        Instantiate(enemigoPrefab, puntosSpawn[Random.Range(0,puntosSpawn.Length)].position, Quaternion.identity); //lengh: hasta el último punto 
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Spawnear()
    {
        for (int i = 0; i < numeroNiveles; i++) //niveles (5) // i =niveles
        {
            for(int j = 0; j < rondasporNivel; j++) //Rondas (5) //j =Rondas
            {
                for(int k= 0; k < spwansPorRonda; k++) // Spawns(10) //k=Spwans // < (...= ultimo cosa)
                {
                    int indiceAleatorio = Random.Range(0, puntosSpawn.Length);
                    Instantiate(enemigoPrefab, puntosSpawn[indiceAleatorio].position, Quaternion.identity);

                    yield return new WaitForSeconds(esperaEntreSpawns);
                }

                //Actualizar texto de ronda
                yield return new WaitForSeconds(esperaEntreRondas);
            }
            //yield return new WaitForSeconds();
        }
    }

    private IEnumerator SpawneoEnemigo()
    {
        while(true)
        {
            Instantiate(enemigoPrefab, puntosSpawn[Random.Range(0, puntosSpawn.Length)].position, Quaternion.identity); //lengh: hasta el último punto 
            yield return new WaitForSeconds(2);
        }
    }
}

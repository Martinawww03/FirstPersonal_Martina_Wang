using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ParteDeEnemigo : MonoBehaviour
{
    [SerializeField] private Enemigo mainScript;
    [SerializeField] private float multiplicadorDanno;

    public void RecibirDanno(float dannoRecibido)
    {
        mainScript.Vida -= dannoRecibido * multiplicadorDanno;
        if (mainScript.Vida <= 0)
        {
            mainScript.Morir();
        }
    }

    public void Explotar()
    {
        mainScript.Morir();
    }

    
}

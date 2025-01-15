using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Contador : MonoBehaviour
{
    public float segundosTotal = 60f; // Tiempo inicial en segundos
    [SerializeField] TMP_Text textSegundos;
    private bool timerIsRunning = false;
    [SerializeField] GameObject menuGameOver;

    void Start()
    {
        //if (textSegundos == null || menuGameOver == null)
        //{
        //    Debug.LogError("Ndhuasoid");
        //    return;
        //}

        // Asegurarse de que el Canvas de Game Over esté oculto al inicio
        menuGameOver.SetActive(false);

        // Iniciar el temporizador
        timerIsRunning = true;
        ContadorTiempo();
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (segundosTotal > 0) //Comprueba si quedan segundos en el temporizador.
            {
                // Reducir el tiempo restante
                segundosTotal -= Time.deltaTime; //Si quedan segundos, reduce el tiempo restante.
                ContadorTiempo();
            }
            else
            {
                // El temporizador ha terminado
                segundosTotal = 0;
                timerIsRunning = false;
                ContadorTiempo();
                OnTimerEnd();
            }
        }
    }

    void ContadorTiempo()
    {
        // cambiarlo a minutos y segundos 
        int minutes = Mathf.FloorToInt(segundosTotal / 60);
        int seconds = Mathf.FloorToInt(segundosTotal % 60);
        textSegundos.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void OnTimerEnd()
    {
        Time.timeScale = 0f;
        // Mostrar el Canvas de Game Over
        menuGameOver.SetActive(true);
        

    }
}

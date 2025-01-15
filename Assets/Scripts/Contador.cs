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
        if (textSegundos == null || menuGameOver == null)
        {
            Debug.LogError("No se asignaron todos los elementos necesarios en el Inspector.");
            return;
        }

        // Asegurarse de que el Canvas de Game Over esté oculto al inicio
        menuGameOver.SetActive(false);

        // Iniciar el temporizador
        timerIsRunning = true;
        UpdateTimerDisplay();
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (segundosTotal > 0)
            {
                // Reducir el tiempo restante
                segundosTotal -= Time.deltaTime;
                UpdateTimerDisplay();
            }
            else
            {
                // El temporizador ha terminado
                segundosTotal = 0;
                timerIsRunning = false;
                UpdateTimerDisplay();
                OnTimerEnd();
            }
        }
    }

    void UpdateTimerDisplay()
    {
        // Actualiza el texto del temporizador en formato mm:ss
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvaManager : MonoBehaviour
{
    [SerializeField] GameObject menuPausa;
    [SerializeField] GameObject menuGameOver;
    
    public void Pausa()
    {
        Time.timeScale = 1.0f;
        menuPausa.SetActive(false);
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void RegresarAMEnu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1.0f;
    }
}

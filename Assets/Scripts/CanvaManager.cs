using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvaManager : MonoBehaviour
{
    [SerializeField] GameObject menuPausa;
    [SerializeField] GameObject menuGameOver;
    [SerializeField] TMP_Text puntos;
    [SerializeField] TMP_Text vidasTexto;
    float vidas;
    float vidasMaxima;

    //public GameObject MenuGameOver { get => menuGameOver; set => menuGameOver = value; }

    public void RegresarPartida()
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
    private void Update()
    {
        vidas=GameObject.FindObjectOfType<Player>().VidasActuales; //Busca el primer gameobject de tipo player.
        vidasMaxima= GameObject.FindObjectOfType<Player>().VidasMax; //
    }
}

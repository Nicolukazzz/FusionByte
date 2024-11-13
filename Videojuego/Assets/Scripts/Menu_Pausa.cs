using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Menu_Pausa : MonoBehaviour
{

    private bool pausado = false;
    [SerializeField] private GameObject canva;
    [SerializeField] private Scene_Manager manager;
    [SerializeField] private Player_Health Player_Health_Class;
    void Start()
    {
        canva.SetActive(false);

    }


    public void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {

            AlternarPausa();

        }

    }

    public void AlternarPausa()
    {

        pausado = !pausado;

        if (pausado)
        {
            canva.SetActive(true);
            Time.timeScale = 0f;

        }
        else
        {
            canva.SetActive(false);
            Time.timeScale = 1f;

        }
    }


    public void Continuar()
    {
        canva.SetActive(false);
        Time.timeScale = 1f;
    }


    public void Reiniciar()
    {
        canva.SetActive(false);
        Time.timeScale = 1f;
        Player_Health_Class.RespawnPlayer();
    }


    public void Salir()
    {
        canva.SetActive(false);
        Time.timeScale = 1f;
        manager.GameStart();
    }



}


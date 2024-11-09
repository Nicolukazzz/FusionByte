using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{
    public GameManager gameManager;
    public TextMeshProUGUI Puntos;
    public TextMeshProUGUI Puntos2;
    public TextMeshProUGUI Puntos3;

    public GameObject[] vidas;
    public GameObject[] vidasPerdidas;

    private void Start()
    {
        vidasPerdidas[0].SetActive(false);
        vidasPerdidas[1].SetActive(false);
        vidasPerdidas[2].SetActive(false);
        vidasPerdidas[3].SetActive(false);
        vidasPerdidas[4].SetActive(false);
    }
   
    public void ActualizarPuntos(int puntosTotales)
    {
        Puntos.text = gameManager.PuntosTotales.ToString();
    }
    public void ActualizarPuntos2(int puntosTotales2)
    {
        Puntos2.text = gameManager.PuntosTotales2.ToString();
    }
    public void ActualizarPuntos3(int puntosTotales3)
    {
        Puntos3.text = gameManager.PuntosTotales3.ToString();
    }

    public void DesactivarVida(int indice)
    {
        vidas[indice].SetActive(false);
        vidasPerdidas[indice].SetActive(true);
    }
}

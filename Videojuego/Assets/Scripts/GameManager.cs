using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Vector3 checkpointPosition;
    [SerializeField] private Transform startCheckpoint;
    [SerializeField] private Transform endCheckpoint;
    public int PuntosTotales { get { return puntosTotales; } }
    private int puntosTotales;

    public int PuntosTotales2 { get { return puntosTotales2; } }
    private int puntosTotales2;

    public int PuntosTotales3 { get { return puntosTotales3; } }
    private int puntosTotales3;

    public HUD hud;
    private int VidasActuales=5;
   
    private Transform player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    public void SetCheckpoint(Vector3 newCheckpoint)
    {
        checkpointPosition = newCheckpoint;
    }

    public void setStartCheckpoint()
    {
        checkpointPosition = startCheckpoint.position;
    }

    public void Respawn()
    {
        player.transform.position = checkpointPosition;
        VidasActuales = VidasActuales-1;
        hud.DesactivarVida(VidasActuales);
    }

    public void SumarPuntos(int puntosASumar)
    {
        puntosTotales += puntosASumar;
        hud.ActualizarPuntos(puntosTotales);
    }
    public void SumarPuntos2(int puntosASumar2)
    {
        puntosTotales2 += puntosASumar2;
        hud.ActualizarPuntos2(puntosTotales2);
    }
    public void SumarPuntos3(int puntosASumar3)
    {
        puntosTotales3 += puntosASumar3;
        hud.ActualizarPuntos3(puntosTotales3);
    }
}


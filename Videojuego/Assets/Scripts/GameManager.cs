using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class GameManager : MonoBehaviour
{


    private Vector3 checkpointPosition;
    [SerializeField] private Character_Controller characterController;
    [SerializeField] private Transform startCheckpoint;
    [SerializeField] private Transform endCheckpoint;
    [SerializeField] private Player_Health playerHealthClass;
    [SerializeField] CinemachineVirtualCamera camera_follow;

    public int puntajeFinal;
    public int PuntosTotalesInsignia { get { return puntosTotalesInsignia; } }
    private int puntosTotalesInsignia;

    public int PuntosTotalesCalavera { get { return puntosTotalesCalavera; } }
    private int puntosTotalesCalavera;

    public int PuntosTotalesOjo { get { return puntosTotalesOjo; } }
    private int puntosTotalesOjo;

    public HUD hud;
    public Puntaje hudPuntaje;
    private int VidasActuales=5;
    private Collectable_Controller tipo;
    private Checkpoint Checkpoint;
   
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
        camera_follow.Follow = player;
    }

    public void SumarPuntos(int puntosASumar, TypeCollectable typeCollectable)
    {
        if (typeCollectable == TypeCollectable.INSIGNIA)
        {
            puntosTotalesInsignia += puntosASumar;
            hud.ActualizarPuntos(typeCollectable);
        }
        if (typeCollectable == TypeCollectable.CALAVERA)
        {
            puntosTotalesCalavera += puntosASumar;
            hud.ActualizarPuntos(typeCollectable);
        }
        if (typeCollectable == TypeCollectable.OJO)
        {
            puntosTotalesOjo += puntosASumar;
            hud.ActualizarPuntos(typeCollectable);
        }   
    }
    public void PuntajeFinal()
    {
        puntajeFinal = puntosTotalesCalavera + puntosTotalesInsignia + puntosTotalesOjo;
        hudPuntaje.EstrellasPantalla(puntajeFinal);
        
    }

    public void RespawnPlayer()
    {
        characterController.enabled = true;
        setStartCheckpoint();
        Respawn();
        playerHealthClass.setCurrenHealth(playerHealthClass.getMaxHealth());
        hud.ResetVidas();
        playerHealthClass.setIsDead(false);// Resetear el estado después de respawnear
    }


}


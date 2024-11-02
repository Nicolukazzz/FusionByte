using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Vector3 checkpointPosition;
    [SerializeField] private Transform startCheckpoint;
    [SerializeField] private Transform endCheckpoint;
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
    }
}


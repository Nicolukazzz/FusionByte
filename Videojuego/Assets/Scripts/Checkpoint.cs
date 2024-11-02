using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;


public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager player = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
            if (player != null)
            {
                player.SetCheckpoint(transform.position);
            }
        }
    }
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;


public class Checkpoint : MonoBehaviour
{
    [SerializeField] private bool isEndCheckpoint;
    [SerializeField] private Scene_Manager sceneManager;
    [SerializeField] private AudioClip CheckpointSound;
    //[SerializeField] private int nextLevel;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager player = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
            if (player != null)
            {
                player.SetCheckpoint(transform.position);
                ControladorSonidos.Instance.EjecutarSonido(CheckpointSound);
            }

            if (isEndCheckpoint == true)
            {
                sceneManager.selectLevel(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}

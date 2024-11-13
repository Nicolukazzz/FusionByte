using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class LimiteMapa : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera camera_follow;
    private int damage = 1;
    private GameManager gameManager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            
            gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
            Player_Health health = collision.GetComponent<Player_Health>();
            health.takeDamage(damage);
            camera_follow.Follow = null;
            StartCoroutine(RespawnAfterDelay());

        }
    }

    private IEnumerator RespawnAfterDelay()
    {
        // Espera 1 segundo
        yield return new WaitForSeconds(1f);

        // Llama a la función `Respawn` en el GameManager
        gameManager.Respawn();
    }

}

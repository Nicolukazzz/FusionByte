using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimiteMapa : MonoBehaviour
{
    private int damage = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Character_Controller player = collision.GetComponent<Character_Controller>();
            Player_Health health = player.GetComponent<Player_Health>();
            health.takeDamage(damage);
            player.Respawn();
        }
    }
}

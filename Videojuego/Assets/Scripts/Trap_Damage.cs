using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_Damage : MonoBehaviour
{
    [SerializeField]private int damage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector2 damageDirection = new Vector2(transform.position.x, 0);

            print("collide");
            collision.gameObject.GetComponent<Player_Health>().takeDamage(damageDirection ,damage);
        }
    }
}

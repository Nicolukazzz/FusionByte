using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_damage : MonoBehaviour
{

    [SerializeField] private int damage;

    private Animator animator;
    private Player_Health health;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            health = collision.gameObject.GetComponent<Player_Health>();

            //Vector2 damageDirection = transform.position;
            Vector2 damageDirection = transform.position;
            health.takeDamage(damageDirection, damage);
            //health.playerDead();
        }
    }
}

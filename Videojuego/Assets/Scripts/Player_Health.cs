using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Health : MonoBehaviour
{
    [SerializeField] private int currentHealth;
    [SerializeField] private int maxHealth = 5;
    private bool recibiendoDano;
    public float FuerzaRebote = 10f;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void takeDamage(Vector2 direccion, int damage)
    {
        if (!recibiendoDano)
        {
            recibiendoDano = true;
            Vector2 rebote = new Vector2(transform.position.x - direccion.x, 0.2f).normalized;
            print(rebote);
            gameObject.GetComponent<Rigidbody2D>().AddForce(rebote * FuerzaRebote, ForceMode2D.Impulse);
            currentHealth -= damage;
            print("taking damage");
        }

        recibiendoDano = false;
    }

    public bool getRecibiendoDano()
    {
        return recibiendoDano;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Health : MonoBehaviour
{
    [SerializeField] private int currentHealth;
    [SerializeField] private int maxHealth = 5;
    private bool recibiendoDano;
    private bool isDead = false;
    public float FuerzaRebote = 10f;
    
    private Character_Controller characterController;
    private GameManager gameManager;
    private Checkpoint checkpoint;

    void Start()
    {
        currentHealth = maxHealth;
        characterController = GetComponent<Character_Controller>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    private void Update()
    {
        playerDead();

        if (Input.GetKeyDown(KeyCode.R))
        {
            gameManager.Respawn();
        }
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
    public void takeDamage(int damage)
    {
        if (!recibiendoDano)
        {
            recibiendoDano = true;
            currentHealth -= damage;
            print("taking damage");
        }

        recibiendoDano = false;
    }

    public bool getRecibiendoDano()
    {
        return recibiendoDano;
    }

    public void playerDead()
    {
        if (currentHealth == 0)
        {
            gameManager.setStartCheckpoint();
            gameManager.Respawn();
            currentHealth = maxHealth;
        }
    }


}

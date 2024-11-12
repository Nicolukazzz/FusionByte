using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.HID;

public class Player_Health : MonoBehaviour
{
    [SerializeField] private int currentHealth;
    [SerializeField] private int maxHealth = 5;
    private bool recibiendoDano = false;
    private bool isDead = false;
    public float FuerzaRebote = 10f;
    
    private Character_Controller characterController;
    private GameManager gameManager;
    private HUD hud;
    private Rigidbody2D rb;
    private Animator animator;

    void Start()
    {
        currentHealth = maxHealth;
        characterController = GetComponent<Character_Controller>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
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
            animator.SetBool("RecibeDano", recibiendoDano);
            currentHealth -= damage;

            rb.velocity = Vector2.zero;

            Vector2 rebote = new Vector2(rb.transform.position.x - direccion.x, 1f).normalized;
            rb.AddForce(rebote * FuerzaRebote, ForceMode2D.Impulse);

            hud.DesactivarVida(currentHealth);
        }
    }

    public void desactivarDano()
    {
        recibiendoDano = false;
        animator.SetBool("RecibeDano", recibiendoDano);
    }

    public void takeDamage(int damage)
    {
        if (recibiendoDano == false)
        {
            recibiendoDano = true;
            currentHealth -= damage;
            hud.DesactivarVida(currentHealth);

            animator.SetBool("RecibeDano", recibiendoDano);
            print("taking damage");
        }

        recibiendoDano = false;
        animator.SetBool("RecibeDano", recibiendoDano);
    }

    public bool getRecibiendoDano()
    {
        return recibiendoDano;
    }

    public void playerDead()
    {
        if (currentHealth == 0 && !isDead)
        {
            isDead = true; // Evita que se llame múltiples veces
            characterController.enabled = false;
            rb.velocity = Vector2.zero;

            // Llama a la función `Respawn` después de 1 segundo (o la duración de la animación de recibir daño)
            Invoke("RespawnPlayer", 1f);
        }
    }

    private void RespawnPlayer()
    {
        characterController.enabled = true;
        gameManager.setStartCheckpoint();
        gameManager.Respawn();
        currentHealth = maxHealth;
        hud.ResetVidas();
        isDead = false; // Resetear el estado después de respawnear
    }
}

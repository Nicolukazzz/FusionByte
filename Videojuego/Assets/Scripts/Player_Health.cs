using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.HID;

public class Player_Health : MonoBehaviour
{
    [SerializeField] private int currentHealth;
    [SerializeField] private int maxHealth = 5;
    [SerializeField] private AudioClip damageSound;
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

    public void setIsDead(bool isDead)
    {
        this.isDead = isDead;

    }


    public void setCurrenHealth(int health)
    {
        currentHealth = health;

    }

    public int getMaxHealth()
    {
        return maxHealth;
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
            ControladorSonidos.Instance.EjecutarSonido(damageSound);
            characterController.enabled = false;
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
        characterController.enabled = true;
    }
 
    public void takeDamage(int damage)
    {
        if (recibiendoDano == false)
        {
            recibiendoDano = true;
            ControladorSonidos.Instance.EjecutarSonido(damageSound);
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
            Invoke("RespawnFromGameManager", 1f);
        }
    }
    private void RespawnFromGameManager()
    {
        gameManager.RespawnPlayer();
    }
}


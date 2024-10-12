using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Controller : MonoBehaviour
{
    public float Speed = 10f;
    public float JumpForce = 12f;
    public float FuerzaRebote = 10f;
    public float MaxHoldTime = 0.5f; // Tiempo m�ximo que se puede mantener presionada la tecla de salto
    public LayerMask capaFloor;
    public int MaxJumps = 2;
    public float fallMultiplier = 2.5f; // Factor que incrementa la velocidad de ca�da
    public float lowJumpMultiplier = 2f; // Factor que desacelera la ca�da cuando se suelta la tecla

    private bool LookRight = true;
    private int RestJumps;
    private Rigidbody2D rigidbody;
    private BoxCollider2D boxCollider;

    private bool isJumping;
    private float jumpTimeCounter;

    private bool RecibiendoDano;
    private Animator animator;

    public void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Movement();
        Jump();
        ApplyGravityModifiers();
    }

    public void RecibeDano(Vector2 direccion, int cantDano)
    {
        if (!RecibiendoDano)
        {
            RecibiendoDano = true;
            Vector2 rebote = new Vector2(transform.position.x - direccion.x, 1).normalized;
            rigidbody.AddForce(rebote * FuerzaRebote, ForceMode2D.Impulse);
        }

    }

    public void DesactivarDano()
    {
        RecibiendoDano = false;
    }
    bool InFloor()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, new Vector2(boxCollider.bounds.size.x, boxCollider.bounds.size.y), 0f, Vector2.down, 0.2f, capaFloor);
        return raycastHit.collider != null;
    }

    void Jump()
    {
        // Si el personaje est� en el suelo, restablece el n�mero de saltos disponibles
        if (InFloor())
        {
            RestJumps = MaxJumps;
            animator.SetBool("InFloor",true);
          
        }
        if (!InFloor())
        {
            animator.SetBool("InFloor", false);
        }

        // Inicia el salto
        if (Input.GetKeyDown(KeyCode.Space) && RestJumps > 0)
        {
            isJumping = true;
            jumpTimeCounter = MaxHoldTime;
            RestJumps--;
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, JumpForce);
        }

        // Mant�n el salto mientras se mantenga presionada la tecla

        if (Input.GetKey(KeyCode.Space) && isJumping)
        {
            if (jumpTimeCounter > 0)
            {
                rigidbody.velocity = new Vector2(rigidbody.velocity.x, JumpForce);
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }

        // Finaliza el salto al soltar la tecla
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }
    }

    void ApplyGravityModifiers()
    {
        if (rigidbody.velocity.y < 0)
        {
            // Aplica un multiplicador para acelerar la ca�da
            rigidbody.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rigidbody.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            // Aplica un multiplicador para suavizar la ca�da si se suelta la tecla de salto
            rigidbody.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    void Movement()
    {
        // Movimiento del personaje
        float inputMovement = Input.GetAxis("Horizontal");
        animator.SetFloat("Horizontal",Mathf.Abs(inputMovement));
        animator.SetFloat("VelocidadY", rigidbody.velocity.y);
        rigidbody.velocity = new Vector2(inputMovement * Speed, rigidbody.velocity.y);
        Orientation(inputMovement);
        animator.SetBool("RecibeDano",RecibiendoDano);

    }

    void Orientation(float inputMovement)
    {
        // Orientaci�n del personaje
        if ((LookRight && inputMovement < 0) || (!LookRight && inputMovement > 0))
        {
            LookRight = !LookRight;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemycontroller : MonoBehaviour
{
    [SerializeField] private float vida = 100;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Transform transform;
    private bool isDead;
    private bool recibiendoDano;

    private void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        transform = this.GetComponent<Transform>();
    }

    public void TomarDano(float Dano)
    {

        do
        {
            if (vida < Dano)
            {
                vida = 0;
            }
            else
            {
                vida -= Dano;
            }
            recibiendoDano = true;
        } while (vida > 0 && !recibiendoDano && !isDead);

        recibiendoDano = false;

        if (vida <= 0 || isDead)
        {
            Muerte();
        }
    }

    private void Muerte()
    {
        isDead = true;
        //animator.SetTrigger("Muerte");
        print("Is Dead");
        spriteRenderer.color = Color.red;
        transform.localRotation = Quaternion.Euler(0, 0, 90);
    }

    public bool getIsDead()
    {
        return isDead;
    }
}


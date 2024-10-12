using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemycontroller : MonoBehaviour
{
    [SerializeField] private float vida = 100;
    private Animator animator;
    private bool isDead;
    private bool recibiendoDano;

    private void Start()
    {
        animator = GetComponent<Animator>();
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

        if (vida <= 0)

        {
            Muerte();
        }
    }

    private void Muerte()
    {
        isDead = true;
        animator.SetTrigger("Muerte");
    }

    public bool getIsDead()
    {
        return isDead;
    }
}


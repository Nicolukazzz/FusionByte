using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemycontroller : MonoBehaviour
{
    [SerializeField] private float vida = 100;
    private Animator animator;
    private bool recibeDano = false;
    [SerializeField] private bool isDead = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void TomarDano(float Dano)
    {
        
        do
        {
            vida -= Dano;
            recibeDano = true;

        }while (vida > 0 && !recibeDano && !isDead);

        recibeDano = false;

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


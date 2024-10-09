using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemycontroller : MonoBehaviour
{
    [SerializeField] private float vida=100;
    private Animator animator;

    private void Start()
    {
        animator=GetComponent<Animator>();
    }

    public void TomarDano(float Dano)
    {
        vida=vida-Dano;
        if(vida<=0)
        {
            Muerte();
        }
    }

    private void Muerte()
    {
        animator.SetTrigger("Muerte");
    }
}


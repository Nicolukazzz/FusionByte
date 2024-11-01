using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuntoControl : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Objeto tocado: " + other.gameObject.name);
        if (other.CompareTag("Player"))
        {
            Debug.Log("Jugador ha activado el punto de control: " + gameObject.name);
            animator.SetTrigger("Activar");
            ControladorJuego.Instance.UltimoPuntoControl(gameObject);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable_Controller : MonoBehaviour
{
    public int valor = 1;
    public GameManager gameManager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            print("correcto");
            gameManager.SumarPuntos(valor);
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            Destroy(this.gameObject);
        }
    }
}

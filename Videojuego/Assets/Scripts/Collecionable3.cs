using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collecionable3 : MonoBehaviour
{
    public int valor = 1;
    public GameManager gameManager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            print("correcto");
            gameManager.SumarPuntos3(valor);
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            Destroy(this.gameObject);
        }
    }

}

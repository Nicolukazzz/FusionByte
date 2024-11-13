using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeCollectable
{
    OJO, INSIGNIA, CALAVERA
}

public class Collectable_Controller : MonoBehaviour
{

    public int valor = 1;
    
    private GameManager gameManager;
    [SerializeField] TypeCollectable tipo;

    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (tipo == TypeCollectable.OJO)
            {
                gameManager.SumarPuntos(valor, TypeCollectable.OJO);
                
            }
            if (tipo == TypeCollectable.INSIGNIA)
            {
                gameManager.SumarPuntos(valor, TypeCollectable.INSIGNIA);
                
            }
            if (tipo == TypeCollectable.CALAVERA)
            {
                gameManager.SumarPuntos(valor, TypeCollectable.CALAVERA);
                
            }
            print("correcto");
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            Destroy(this.gameObject);
        }
       
    }
}

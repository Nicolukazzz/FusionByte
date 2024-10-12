using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable_Controller : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            print("correcto");
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            Destroy(gameObject, 2f);
        }
    }
}

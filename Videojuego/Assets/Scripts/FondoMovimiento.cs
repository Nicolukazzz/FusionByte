using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Fondo : MonoBehaviour
{
    [SerializeField] private Vector2 velocidadMovimiento;
    private Vector2 offset;
    private Material material;
    private Rigidbody2D jugadorRB;

    private void Start()
    {
        offset.y = 0;
    }
    private void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
       
        jugadorRB = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        offset.x = (jugadorRB.velocity.x / 10) * velocidadMovimiento.x * Time.deltaTime;
        
        material.mainTextureOffset+= offset;
    }
}

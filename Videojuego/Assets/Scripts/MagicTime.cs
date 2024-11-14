using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicTime : MonoBehaviour
{
    [SerializeField] private float tiempoDesaparicion;

    private void Start()
    {
        Destroy(gameObject,tiempoDesaparicion);
    }
}

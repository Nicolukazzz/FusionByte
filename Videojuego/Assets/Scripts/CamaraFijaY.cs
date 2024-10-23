using UnityEngine;

public class CamaraFijaY : MonoBehaviour
{
    [SerializeField] private Transform jugador; // Referencia al transform del jugador
    [SerializeField] private float suavizado = 0.1f; // Factor de suavizado
    private float posYCamara; // Posición Y fija de la cámara

    private void Awake()
    {
        // Guardar la posición Y inicial de la cámara
        posYCamara = transform.position.y;
    }

    private void Update()
    {
        // Obtener la posición X del jugador
        float posXJugador = jugador.position.x;

        // Suavizar el movimiento de la cámara en X
        float nuevaPosX = Mathf.Lerp(transform.position.x, posXJugador, suavizado);

        // Actualizar la posición de la cámara, manteniendo Y fija
        transform.position = new Vector3(nuevaPosX, posYCamara, transform.position.z);
    }
}

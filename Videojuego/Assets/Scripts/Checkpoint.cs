using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;



public class Checkpoint : MonoBehaviour
{
    [SerializeField] private bool isEndCheckpoint;
    [SerializeField] private Scene_Manager sceneManager;
    [SerializeField] private AudioClip CheckpointSound;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private float tiempoEspera;

    private Puntaje puntaje;
    private Animator animator;
    //[SerializeField] private int nextLevel;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager player = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
            if (player != null)
            {
                player.SetCheckpoint(transform.position);
                animator.SetBool("IsCheckpointActive", true);
                ControladorSonidos.Instance.EjecutarSonido(CheckpointSound);
            }

            if (isEndCheckpoint)
            {
                gameManager.PuntajeFinal();

                StartCoroutine(EsperarYContinuar());
                
            }
        }
    }

    private IEnumerator EsperarYContinuar()
    {
        // Espera el tiempo especificado
        yield return new WaitForSeconds(tiempoEspera);

        // Cambia al siguiente nivel después de la espera
        sceneManager.selectLevel(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
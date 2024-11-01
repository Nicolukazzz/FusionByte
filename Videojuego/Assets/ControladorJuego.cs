using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorJuego : MonoBehaviour
{
    public static ControladorJuego Instance;
    [SerializeField] private GameObject[] puntosDeControl;
    [SerializeField] private GameObject Player;

    private int indexPuntosControl;

    private void Awake()
    {
        Instance = this;

        if (indexPuntosControl >= puntosDeControl.Length)
        {
            PlayerPrefs.SetInt("puntosIndex",0);
            indexPuntosControl = 0;
        }

     
            indexPuntosControl = PlayerPrefs.GetInt("puntosIndex");
            Instantiate(Player, puntosDeControl[indexPuntosControl].transform.position, Quaternion.identity);
       
       

    }


    public void UltimoPuntoControl(GameObject puntoControl)
    {
        for (int i = 0; i < puntosDeControl.Length; i++)
        {
            if (puntosDeControl[i] == puntoControl&&i>indexPuntosControl)
            {
                PlayerPrefs.SetInt("puntosIndex", i);

            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))

        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

}

using UnityEngine;
using UnityEngine.SceneManagement;

public class ScnMng : MonoBehaviour
{
    void Start()
    {
        // Inicia en la Escena 1
        //SceneManager.LoadScene("Pantalla start");
    }

    void Update()
    {
        // Cambia a la Escena 2 al recibir cualquier input
        if (Input.anyKeyDown)
        {
            CambiarAEscena2();
        }

        // Cambia a la Escena 3 cuando la posición Y de la cámara es menor que -60 en la Escena 2
        if (SceneManager.GetActiveScene().name == "PantallaInicio" && Camera.main.transform.position.y < -60f)
        {
            CambiarAEscena3();
        }
    }

    void CambiarAEscena2()
    {
        SceneManager.LoadScene("PantallaInicio");
    }

    void CambiarAEscena3()
    {
        SceneManager.LoadScene("MAP_P1_Rojo_Unity");
    }
}
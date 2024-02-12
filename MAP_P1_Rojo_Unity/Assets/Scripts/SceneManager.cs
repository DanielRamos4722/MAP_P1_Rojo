using UnityEngine;
using UnityEngine.SceneManagement;

public class ScnMng : MonoBehaviour
{
    void Start()
    {
        Screen.SetResolution(640, 480, true);
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
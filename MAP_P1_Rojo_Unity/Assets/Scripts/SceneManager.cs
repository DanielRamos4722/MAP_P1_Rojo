using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScnMnger : MonoBehaviour
{
    void Update()
    {
        // Cambia a la Escena 2 al recibir cualquier input
        if (SceneManager.GetActiveScene().name == "Pantalla start")
        {
            if (Input.anyKeyDown)
            {
                CambiarAEscena2();
            }
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

using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScnMnger : MonoBehaviour
{
    void Update()
    {
        // Cambia a la Escena 2 al recibir cualquier input
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            if (Input.anyKeyDown)
            {
                CambiarAEscena3();
            }
        }
        // Cambia a la Escena 3 cuando la posición Y de la cámara es menor que -60 en la Escena 2
        if (SceneManager.GetActiveScene().buildIndex == 0 && Camera.main.transform.position.y < -60f)
        {
            CambiarAEscena3();
        }
    }

    void CambiarAEscena2()
    {
        SceneManager.LoadScene(0);
    }

    void CambiarAEscena3()
    {
        SceneManager.LoadScene(1);
    }
}

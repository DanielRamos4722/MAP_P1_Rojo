using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PantallaInicio : MonoBehaviour
{
    [SerializeField]
    public float velocidadMovimiento = 1.2f;
    public Vector3 primeraPosicionFinal = new Vector3(0f, -8.20f, 0f);
    public Vector3 segundaPosicionFinal = new Vector3(0f, -77.5f, 0f);
    public float tiempoDeEspera = 4f;

    void Start()
    {
        // Inicia la corrutina para mover la cámara hacia abajo
        StartCoroutine(MoverYEsperar());
    }

    IEnumerator MoverYEsperar()
    {
        // Mueve la cámara hacia abajo hasta alcanzar la primera posición final
        while (transform.position.y > primeraPosicionFinal.y)
        {
            transform.Translate(Vector3.down * velocidadMovimiento * Time.deltaTime);
            yield return null;
        }

        // Espera durante 4 segundos en la primera posición final
        yield return new WaitForSeconds(tiempoDeEspera);

        // Mueve la cámara hacia abajo hasta alcanzar la segunda posición final
        while (transform.position.y > segundaPosicionFinal.y)
        {
            transform.Translate(Vector3.down * velocidadMovimiento * Time.deltaTime);
            yield return null;
        }

        // Espera durante 4 segundos en la segunda posición final
        yield return new WaitForSeconds(tiempoDeEspera);

        // Continúa moviendo la cámara hacia abajo en un bucle infinito
        while (true)
        {
            transform.Translate(Vector3.down * velocidadMovimiento * Time.deltaTime);
            yield return null;
        }
    }
}





using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PantallaInicio : MonoBehaviour
{
    [SerializeField]
    public float velocidadMovimiento = 1.2f;
    public Vector3 primeraPosicionFinal = new Vector3(0f, -8.22f, 0f);
    public Vector3 segundaPosicionFinal = new Vector3(0f, -77.8f, 0f);
    public float tiempoDeEspera = 4f;

    void Start()
    {
        // Inicia la corrutina 
        StartCoroutine(MoverYEsperar());
    }

    IEnumerator MoverYEsperar()
    {
        // Mueve la c�mara hacia abajo hasta alcanzar la primera posici�n final
        while (transform.position.y > primeraPosicionFinal.y)
        {
            transform.Translate(Vector3.down * velocidadMovimiento * Time.deltaTime);
            yield return null;
        }

        // Espera durante 4 segundos en la primera posici�n final
        yield return new WaitForSeconds(tiempoDeEspera);

        // Mueve la c�mara hacia abajo hasta alcanzar la segunda posici�n final
        while (transform.position.y > segundaPosicionFinal.y)
        {
            transform.Translate(Vector3.down * velocidadMovimiento * Time.deltaTime);
            yield return null;
        }

        // Espera durante 4 segundos en la segunda posici�n final
        yield return new WaitForSeconds(tiempoDeEspera);

        // Contin�a moviendo la c�mara hacia abajo en un bucle infinito
        while (true)
        {
            transform.Translate(Vector3.down * velocidadMovimiento * Time.deltaTime);
            yield return null;
        }
    }
}


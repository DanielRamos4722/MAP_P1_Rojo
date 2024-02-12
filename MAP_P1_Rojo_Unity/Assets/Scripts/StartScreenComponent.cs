using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class StartScreenComponent : MonoBehaviour
{
    void Start()
    {
        // Inicia la corutina que controlará la aparición y desaparición del objeto.
        StartCoroutine(AparecerDesaparecerCoroutine());
    }

    IEnumerator AparecerDesaparecerCoroutine()
    {
        while (true)
        {
            // Hace que el objeto aparezca.
            GetComponent<Renderer>().enabled = true;

            // Espera 0.5 segundos.
            yield return new WaitForSeconds(0.5f);

            // Hace que el objeto desaparezca.
            GetComponent<Renderer>().enabled = false;

            // Espera 0.5 segundos antes de repetir el ciclo.
            yield return new WaitForSeconds(0.5f);
        }
    }
}

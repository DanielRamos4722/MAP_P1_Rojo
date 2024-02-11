using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Audio;

public class Texto : MonoBehaviour
{
    bool first = true;
    public AudioSource clip;
    // Start is called before the first frame update

    [SerializeField] TextMeshProUGUI text;
    [SerializeField]
    string textoAux1;
    [SerializeField]
    string textoAux2;
    IEnumerator Escritura()
    {
        string texto = "";
        for (int i = 0; i < textoAux1.Length; i++)
        {
            texto += textoAux1[i];
            print(texto);
            text.text = texto;
            yield return new WaitForSeconds(0.1f);
        }
    }
    IEnumerator Escritura2()
    {
        string texto = "";
        for (int i = 0; i < textoAux2.Length; i++)
        {
            texto += textoAux2[i];
            print(texto);
            text.text = texto;
            yield return new WaitForSeconds(0.1f);
            clip.Play();
        }
    }
    public void EntrarCueva()
    {
        if (first)
        {
            StartCoroutine(Escritura());
            first = false;
        }
        
    }
    public void EntrarTienda()
    {
        if (first)
        {
            StartCoroutine(Escritura2());
            first = false;
        }

    }
}

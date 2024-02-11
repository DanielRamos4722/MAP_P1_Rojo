using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Audio;

public class Tienda : MonoBehaviour
{
    public AudioSource clip;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Escritura());
        
    }

    [SerializeField] TextMeshProUGUI text;
    string textoAux = "BUY SOMETHIN' WILL YA!";
    IEnumerator Escritura()
    {

        string texto = "";
        yield return new WaitForSeconds(2.0f);
        for (int i = 0; i < textoAux.Length; i++)
        {

            texto += textoAux[i];
            print(texto);
            text.text = texto;
            yield return new WaitForSeconds(0.1f);
            
        }
    }
}

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
    string textoAux = "IT'S DANGEROUS TO GO ALONE! TAKE THIS.";

   
    IEnumerator Escritura()
    {
        string texto = "";
        for (int i = 0; i < textoAux.Length; i++)
        {
            texto += textoAux[i];
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
}

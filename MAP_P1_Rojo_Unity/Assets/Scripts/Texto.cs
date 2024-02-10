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
    void Start()
    {
        
        
    }


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
            
        }
    }

    
    // Update is called once per frame
    void Update()
    {
        
    }
    public void EntrarCueva()
    {
        if (first)
        {
            first = false;
            StartCoroutine(Escritura());
        }
        
    }
}

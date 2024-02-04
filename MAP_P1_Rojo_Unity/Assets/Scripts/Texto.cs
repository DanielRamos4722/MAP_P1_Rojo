using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Texto : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Escritura());
        
    }


    [SerializeField] TextMeshProUGUI text;
    string textoAux = "IT'S DANGEROUS TO GO ALONE! TAKE THIS.";
    IEnumerator Escritura()
    {

        string texto = "";
        yield return new WaitForSeconds(2.0f);
        for (int i = 0; i < textoAux.Length; i++)
        {
            texto += textoAux[i];
            print(texto);
            text.text = texto;
            yield return new WaitForSeconds(0.3f);
        }
    }

    
    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RupiesController : MonoBehaviour
{
    public delegate void Sumarupias(int money);
    public static event Sumarupias sumaRupias;

    [SerializeField] private int cantidadRupias;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if(sumaRupias != null) 
            {
                SumarRupias();
                Destroy(this.gameObject);

            }
        }
         
    }
    private void SumarRupias()
    {
        sumaRupias(cantidadRupias);

    }

}

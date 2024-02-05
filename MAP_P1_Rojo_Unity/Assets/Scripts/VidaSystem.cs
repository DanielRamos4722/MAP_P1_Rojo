using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class VidaSystem : MonoBehaviour
{
    public int vida;
    public int vidaMaxima;

    public Image[] corazon;
  

    public Sprite lleno;
    public Sprite medio;
    public Sprite vacio;
    void Start()
    {

    }



    void Update()
    {
        HealthLogic();
    }

    void HealthLogic()
    {

        if (vida > vidaMaxima)
        {
            vida = vidaMaxima;
        }
        for (int i = 0; i < corazon.Length; i++)
        {
            if (i < vida)
            {
                corazon[i].sprite = lleno;
            }
          
            /* 
            {
                corazon[i].sprite = medio;
            }*/
          
            else
            {
                corazon[i].sprite = vacio;
            }

            if (i < vidaMaxima)
            {
                corazon[i].enabled = true;
            }
            else
            {
                corazon[i].enabled = false;
            }
        }

        if(vida == 0)
        {
            Destroy(gameObject);
        }

    }
}

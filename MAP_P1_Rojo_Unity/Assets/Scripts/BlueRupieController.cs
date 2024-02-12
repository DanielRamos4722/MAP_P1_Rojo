using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static RupiesController;

public class BlueRupieController : MonoBehaviour
{
    PlayerController controller;
    public static event Sumarupias sumaRupias;

    [SerializeField] private int cantidadRupias;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        controller = collision.GetComponent<PlayerController>();
        if (controller != null)
        {
            controller.AddMoney(5);
            SumarRupiasAzules();
            Destroy(gameObject);

        }
    }
    private void SumarRupiasAzules()
    {
        sumaRupias(cantidadRupias);

    }
}

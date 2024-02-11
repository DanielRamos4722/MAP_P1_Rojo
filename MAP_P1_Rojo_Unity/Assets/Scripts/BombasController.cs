using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombasController : MonoBehaviour
{
    public delegate void Sumabombas(int money);
    public static event Sumabombas sumaBombas;

    [SerializeField] private int cantidadBombas;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (sumaBombas != null)
            {
                SumarBombas();
                Destroy(this.gameObject);

            }
        }

    }
    private void SumarBombas()
    {
        sumaBombas(cantidadBombas);

    }

}

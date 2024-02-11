using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compra : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    [SerializeField]
    private Transform desaparece;
    private void OnTriggerEnter2D(Collider2D cosa)
    {
        player = cosa.GetComponent<Transform>();
        if (cosa!=null)
        {
            desaparece.gameObject.SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartController : MonoBehaviour
{
    PlayerController controller;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        controller = collision.GetComponent<PlayerController>();
        if (controller != null)
        {
            controller.AddHealth();
            Destroy(gameObject);

        }
    }
}

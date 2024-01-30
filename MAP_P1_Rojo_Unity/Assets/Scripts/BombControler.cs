using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombControler : MonoBehaviour
{
    PlayerController controller;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        controller = collision.GetComponent<PlayerController>();
        if (controller != null)
        {
            controller.AddBomb();
            Destroy(gameObject);

        }
    }
}

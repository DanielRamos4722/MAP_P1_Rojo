using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalidaCueva : MonoBehaviour
{
    public GameObject camera;
    public GameObject link;

    public Transform puntoEntradaCueva;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController pc = collision.gameObject.GetComponent<PlayerController>();
        if (pc != null)
        {
            if (collision.gameObject.transform.position.x < 2)
            {
                camera.transform.position = new Vector3(0, 0, -10);
                link.transform.position = puntoEntradaCueva.position;
            }
            else
            {
                camera.transform.position = new Vector3(106.8f, 7.15f, -10);
                link.transform.position = puntoEntradaCueva.position;
            }
             
        }
    }
}

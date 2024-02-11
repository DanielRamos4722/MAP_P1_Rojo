using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntradaCueva : MonoBehaviour
{
    public GameObject camera;
    public GameObject link;
    public Texto texto;

    public Transform puntoEntradaCueva;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController pc = collision.gameObject.GetComponent<PlayerController>();
        if (pc != null)
        {
            if (collision.gameObject.transform.position.x<0)
            {

                camera.transform.position = new Vector3(0, -7.2f, -10);
                link.transform.position = puntoEntradaCueva.position;
                texto.EntrarCueva();
            }
            else
            {

                camera.transform.position = new Vector3(13.39f, -7.2f, -10);
                link.transform.position = puntoEntradaCueva.position;
                texto.EntrarTienda();
            }
        }
    }


}

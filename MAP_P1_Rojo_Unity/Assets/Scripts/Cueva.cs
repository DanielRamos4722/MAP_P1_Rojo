using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cueva : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    Vector3 position;
    private void OnTriggerEnter2D(Collider2D cueva)
    {
        if(cueva.tag == "Player")
        {
            SceneManager.LoadScene(2);
        }
        else
        {
            SceneManager.LoadScene(1);
           /* position = new Vector3(-2.88f, 0.62f, 0f);
            player.position = position;*/
        }
    }

}

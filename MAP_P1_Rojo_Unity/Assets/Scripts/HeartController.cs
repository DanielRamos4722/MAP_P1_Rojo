using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class HeartController : MonoBehaviour
{
    PlayerController controller;
    public AudioSource clip;
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        controller = collision.GetComponent<PlayerController>();
       
        if (controller != null)
        {         
            controller.AddHealth();
            clip.Play();
            Destroy(gameObject);
           

        }
    }
}

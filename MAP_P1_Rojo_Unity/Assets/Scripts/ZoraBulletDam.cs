using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoraBulletDam : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        VidaSystem vidaSys = collision.gameObject.GetComponent<VidaSystem>();
        if (vidaSys)
        {
            vidaSys.vida--;
        }
        PlayerController pc = collision.gameObject.GetComponent<PlayerController>();
        if (pc)
        {
            pc.LooseHeath();
        }
    }
}

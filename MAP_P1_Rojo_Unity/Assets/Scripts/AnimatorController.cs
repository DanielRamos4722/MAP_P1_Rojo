using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Audio;

public class AnimatorController : MonoBehaviour
{
    private Rigidbody2D rb;
    public Animator animator;
    public AudioSource clip;
    [SerializeField]
    private Transform player;
    bool horizontal;
    bool vertical;
    void Start()
    {
        rb = player.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    private void Position()
    {
        if(Mathf.Abs(rb.velocity.x) > 0.1f)
        {
            horizontal = true;
        }
        else if (Mathf.Abs(rb.velocity.x) < -0.1f)
        {
            horizontal = false;
        }
        if(Mathf.Abs(rb.velocity.y) > 0.1f)
        {
            vertical = true;
        }
        else if (Mathf.Abs(rb.velocity.y) < -0.1f)
        {
            vertical = false;
        }
    }

    void Update()
    {
        // Detecta las teclas de flecha
        if (vertical)
        {
            animator.SetInteger("AnimState", 0);
        }
        else if (!vertical)
        {
            animator.SetInteger("AnimState", 1);
        }
        else if (horizontal)
        {
            if (transform.rotation == Quaternion.identity)
            {
                animator.SetInteger("AnimState", 2);
            }
            else
            {
                animator.SetInteger("AnimState", 2);
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            }
        }
        else if (!horizontal)
        {
            animator.SetInteger("AnimState", 2);
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        else if (rb.velocity.x == 0 && rb.velocity.y == 0)
        {
            animator.SetInteger("AnimState", 3);
        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            clip.Play();
            animator.SetTrigger("AnimTrigger");
        }
    }

    void SetAnimation(string animationName)
    {
        // Cambia la animación
        animator.Play(animationName);
    }

    
}

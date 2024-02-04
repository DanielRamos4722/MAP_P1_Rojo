using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Detecta las teclas de flecha
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            animator.SetInteger("AnimState", 0);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            animator.SetInteger("AnimState", 1);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
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
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            animator.SetInteger("AnimState", 2);
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            animator.SetInteger("AnimState", 4);
        }
        else if (!Input.anyKey)
        {
            animator.SetInteger("AnimState", 3);
        }
    }

    void SetAnimation(string animationName)
    {
        // Cambia la animación
        animator.Play(animationName);
    }
}

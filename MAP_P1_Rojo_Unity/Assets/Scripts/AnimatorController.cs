using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;

public class AnimatorController : MonoBehaviour
{
    private Rigidbody2D rb;
    Animator animator;
    public AudioSource clip;
    [SerializeField]
    private Transform player;
    bool horizontal;
    bool vertical;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
        /*if (Input.GetKeyDown(KeyCode.UpArrow))
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

        } */
    }

    void SetAnimation(string animationName)
    {
        // Cambia la animación
        animator.Play(animationName);
    }
    public void ToAttack()
    {
        clip.Play();
        animator.SetTrigger("AnimTrigger");
    }
    public void OnMove(InputAction.CallbackContext ctx)
    {
        Vector2 dir = ctx.ReadValue<Vector2>();
        if (dir.sqrMagnitude != 0)
        {
            if (dir.y>0 && Mathf.Abs(dir.y)>Mathf.Abs(dir.x))
            {
                animator.SetInteger("AnimState", 0);
            }
            else if (dir.y< 0 && Mathf.Abs(dir.y) > Mathf.Abs(dir.x))
            {
                animator.SetInteger("AnimState", 1);
            }
            else if (dir.x> 0 && Mathf.Abs(dir.x) > Mathf.Abs(dir.y))
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
            else if (dir.x< 0 && Mathf.Abs(dir.x) > Mathf.Abs(dir.y))
            {
                animator.SetInteger("AnimState", 2);
                transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            }

        }
        else
        {
            animator.SetInteger("AnimState", 3);
        } 
    }


}

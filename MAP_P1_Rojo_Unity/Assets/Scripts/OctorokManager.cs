using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class OctorokManager : MonoBehaviour
{
    Animator anim;
    SpriteRenderer spriteR;
    [SerializeField] GameObject bullet;
    Transform myTransform;

    float speed;
    bool shootCancel = false;
    bool alive = true;
    Quaternion rot = Quaternion.identity;
    public int dir = 4;
    

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        spriteR = GetComponent<SpriteRenderer>();
        myTransform = transform;

        if (gameObject.tag == "OctorokR")
            speed = 0.5f;
        else
            speed = 0.3f;

        StartCoroutine(Interval());
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void MoveTemp(Vector3 vDir)
    {
        myTransform.position += vDir * speed * Time.deltaTime;
    }

    private void Move()
    {
        switch(dir)
        {
            case 0:
                MoveTemp(Vector3.down);
                break;
            case 1:
                MoveTemp(Vector3.left);
                break;
            case 2:
                MoveTemp(Vector3.up);
                break;
            case 3:
                MoveTemp(Vector3.right);
                break;
            default:
                break;
        }
    }

    private void SetDirection()
    {
        int dirAux = 0;
        bool orient = true;
        bool flip = false;

        if (Random.Range(0, 3) == 1 && !shootCancel)
        {
            dirAux = 5;
            StartCoroutine(Shoot());
        }
        else
        {
            if (Random.Range(0, 2) == 1)
            {
                orient = false;
                dirAux++;
            }

            if (Random.Range(0, 2) == 1)
            {
                dirAux += 2;
                flip = true;
            }

            shootCancel = false;
        }

        dir = dirAux;

        if (dir % 2 == 0)
        {
            spriteR.flipY = flip;
            if(flip)
            {
                rot = Quaternion.Euler(0, 0, 180);
            }
            else
            {
                rot = Quaternion.identity;
            }
            anim.SetBool("Front", orient);
        }
        else if (dir != 5)
        {
            spriteR.flipX = flip;
            if(flip)
            {
                rot = Quaternion.Euler(0, 0, 90);
            }
            else
            {
                rot = Quaternion.Euler(0, 0, -90);
            }
            anim.SetBool("Front", orient);
        }
    }

    private IEnumerator Interval()
    {
        yield return new WaitForSeconds(0.6f);

        while(alive)
        {
            SetDirection();
            yield return new WaitForSeconds(Random.Range(0.6f, 1.1f));
        }

        speed = 0;
        anim.SetBool("Alive", false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Playermove playermove = collision.gameObject.GetComponent<Playermove>();

        if(!playermove)
        {
            SetDirection();
        }
    }

    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(0.5f);
        Instantiate(bullet, transform.position, rot);
        shootCancel = true;
    }
    

}

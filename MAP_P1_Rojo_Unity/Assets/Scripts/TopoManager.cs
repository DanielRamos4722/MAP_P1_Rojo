using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopoManager : MonoBehaviour
{
    [SerializeField] GameObject Link;
    Animator anim;
    float speed = 0.01f;
    Transform myTransform;
    Rigidbody2D rb;
    int cont = 0;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        myTransform = rb.transform;
        Link = GameObject.FindGameObjectWithTag("Player");

        StartCoroutine(Ciclo());
    }

    IEnumerator Ciclo()
    {
        Vector3 targetPos;
        float dist = 3;
        Vector3 sentido = Link.transform.position - myTransform.position;

        anim.SetBool("Spawn", false);
        yield return new WaitForSeconds(0.6f);
        if (sentido.x > 0)
        {
            targetPos = myTransform.position - new Vector3(-dist, 0, 0);
        }
        else
        {
            targetPos = myTransform.position - new Vector3(dist, 0, 0);
        }
        while (myTransform.position != targetPos)
        {
            myTransform.position = Vector3.MoveTowards(myTransform.position, targetPos, speed);
            yield return null;
        }
        anim.SetBool("Spawn", true);
        yield return new WaitForSeconds(0.6f);


        while (true)
        {
            int random = Random.Range(0, 2);
            float spawn;
            if(random == 0)
            {
                spawn = 2f;
            }
            else
            {
                spawn = -2f;
            }
            myTransform.position = new Vector3(Link.transform.position.x + spawn, Link.transform.position.y, 0);
            anim.SetBool("Spawn", false);
            yield return new WaitForSeconds(0.6f);
            if (random == 1)
            {
                targetPos = myTransform.position - new Vector3(-dist, 0, 0);
            }
            else
            {
                targetPos = myTransform.position - new Vector3(dist, 0, 0);
            }
            while (myTransform.position != targetPos && cont < 150)
            {
                myTransform.position = Vector3.MoveTowards(myTransform.position, targetPos, speed);
                cont++;
                yield return null;
            }
            cont = 0;
            anim.SetBool("Spawn", true);
            yield return new WaitForSeconds(0.6f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

    }
}

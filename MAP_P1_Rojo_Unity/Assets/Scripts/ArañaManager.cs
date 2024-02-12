using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArañaManager : MonoBehaviour
{
    Animator anim;
    [SerializeField] Rigidbody2D rb;
    Transform myTransform;

    float speed = 0.05f;
    Quaternion rot = Quaternion.identity;
    public int dir = 4;

    Vector3 targetPos1;
    Vector3 targetPos2;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        myTransform = rb.transform;

        StartCoroutine(Interval());
    }

    private void SetDirection()
    {
        dir = Random.Range(0, 6);
        float dist = 0.3f;
        if (dir < 3)
        {
            targetPos1 = myTransform.position + new Vector3(-dist, dist, 0f);
        }
        else
        {
            targetPos1 = myTransform.position + new Vector3(dist, dist, 0f);
        }

        switch (dir)
        {
            case 0:
                targetPos2 = targetPos1 + new Vector3(-dist, dist, 0f);
                break;
            case 1:
                targetPos2 = targetPos1 + new Vector3(-dist, -dist, 0f);
                break;
            case 2:
                targetPos2 = targetPos1 + new Vector3(-dist, -2*dist, 0f);
                break;
            case 3:
                targetPos2 = targetPos1 + new Vector3(dist, dist, 0f);
                break;
            case 4:
                targetPos2 = targetPos1 + new Vector3(dist, -dist, 0f);
                break;
            case 5:
                targetPos2 = targetPos1 + new Vector3(dist, -2*dist, 0f);
                break;
            default:
                break;
        }
    }

    IEnumerator Interval()
    {
        yield return new WaitForSeconds(0.4f);

        while (true)
        {
            SetDirection();
            anim.SetBool("Salto", true);
            while (myTransform.position != targetPos1)
            {
                myTransform.position = Vector3.MoveTowards(myTransform.position, targetPos1, speed);
                yield return null;
            }
            while (myTransform.position != targetPos2)
            {
                myTransform.position = Vector3.MoveTowards(myTransform.position, targetPos2, speed);
                yield return null;
            }
            anim.SetBool("Salto", false);
            yield return new WaitForSeconds(Random.Range(1f, 2.4f));
        }

        speed = 0;
    }
}

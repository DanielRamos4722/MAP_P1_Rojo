using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoraManager : MonoBehaviour
{
    [SerializeField] GameObject Link;
    Animator anim;
    float speed = 0.025f;
    Transform myTransform;
    Rigidbody2D rb;
    [SerializeField] GameObject bulletPrefab;
    BoxCollider2D boxColl;

    Vector3 firstPos;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        myTransform = rb.transform;
        firstPos = myTransform.position;
        boxColl = GetComponent<BoxCollider2D>();
        Link = GameObject.FindGameObjectWithTag("Player");

        StartCoroutine(Ciclo());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Ciclo()
    {
        while(true)
        {
            anim.SetBool("Spawn", true);
            boxColl.enabled = false;

            int dir = Random.Range(0, 4);
            yield return new WaitForSeconds(0.4f);
            Vector3 targetPos = Vector3.zero;

            switch (dir)
            {
                case 0:
                    targetPos = firstPos;
                    break;
                case 1:
                    targetPos = firstPos + new Vector3(0, -2, 0);
                    break;
                case 2:
                    targetPos = firstPos + new Vector3(2, 0, 0);
                    break;
                case 3:
                    targetPos = firstPos + new Vector3(2, -2, 0);
                    break;
                default:
                    break;
            }

            myTransform.position = targetPos;
            yield return new WaitForSeconds(0.4f);
            Vector3 sentido = Link.transform.position - myTransform.position;
            if (sentido.y < 0)
            {
                anim.SetBool("Front", true);
                anim.SetBool("Spawn", false);
                boxColl.enabled = true;
            }
            else
            {
                anim.SetBool("Front", false);
                anim.SetBool("Spawn", false);
                boxColl.enabled = true;
            }

            yield return new WaitForSeconds(0.4f);
            GameObject bullet = Instantiate(bulletPrefab, myTransform.position, myTransform.rotation);
            Vector3 balaDest = Link.transform.position;
            float speedBullet = 0.03f;
            yield return new WaitForSeconds(0.5f);

            while (bullet.transform.position != balaDest)
            {
                bullet.transform.position = Vector3.MoveTowards(bullet.transform.position, balaDest, speedBullet);
                yield return null;
            }
            Destroy(bullet);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    Transform myTransform;
    float speed = 6f;

    private void Start()
    {
        myTransform = transform;
        StartCoroutine(Destroy());
    }

    void Update()
    {
        myTransform.position += -transform.up * speed * Time.deltaTime;
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(4);
        Destroy(gameObject);
    }
}
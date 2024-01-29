using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class OctorokManager : MonoBehaviour
{
    Animator anim;
    Transform myTransform;
    float speed;
    int dir;
    bool orient;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        myTransform = transform;

        if (gameObject.tag == "OtorokR")
            speed = 1.0f;
        else
            speed = 0.5f;

        StartCoroutine("SetDirection");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Move()
    {
        if (orient)
        {

        }
    }

    private IEnumerator SetDirection()
    {
        while(true)
        {
            dir = 0;
            bool flip = false;
            orient = true;

            if (Random.RandomRange(0, 2) == 1)
            {
                orient = false;
                dir++;
            }
            anim.SetBool("Front", orient);

            if (Random.RandomRange(0, 2) == 1)
            {
                myTransform.rotation = Quaternion.Euler(0, 0, 180);
                flip = true;
                dir += 2;
            }

            yield return new WaitForSeconds(Random.RandomRange(0.5f, 1.1f));
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctorokManager : MonoBehaviour
{
    Animator anim;
    Transform myTransform;
    int dir = 0;
    float speed;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        myTransform = transform;

        if (gameObject.tag == "OtorokR")
            speed = 1.0f;
        else
            speed = 0.5f;

        bool orient = true;

        if(Random.RandomRange(0, 2) == 1)
        {
            orient = false;
            dir++;
            
        }
        anim.SetBool("Front", orient);

        if (Random.RandomRange(0, 2) == 1)
        {
            myTransform.rotation = Quaternion.Euler(0, 0, 180);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

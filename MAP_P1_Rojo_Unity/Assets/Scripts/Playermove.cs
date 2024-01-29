using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermove : MonoBehaviour
{
    //CharacterController controller;
    Rigidbody2D rb;
    private Transform _transform;
    // Start is called before the first frame update
    void Start()
    {
        //controller = GetComponent<CharacterController>(); 
        rb = GetComponent<Rigidbody2D>();
        _transform = rb.transform;
    }
    private Vector3 direction = Vector3.zero;
    private float speed = 2f;
    public void Changedirection(Vector3 directions)
    {
        direction = directions;
        direction.Normalize();
        
    }
    // Update is called once per frame
    void Update()
    {
      //controller.Move(direction*Time.deltaTime*speed);  
      _transform.position += (direction * Time.deltaTime * speed);
    }
}

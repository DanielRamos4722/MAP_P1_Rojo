using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermove : MonoBehaviour
{
    CharacterController controller;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();  
    }
    private Vector2 direction = Vector2.zero;
    private float speed = 2f;
    public void Changedirection(Vector2 directions)
    {
        direction = directions;
        
    }
    // Update is called once per frame
    void Update()
    {
      controller.Move(direction*Time.deltaTime*speed);  
    }
}

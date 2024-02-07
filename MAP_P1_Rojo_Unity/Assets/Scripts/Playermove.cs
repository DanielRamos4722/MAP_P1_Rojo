using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Playermove : MonoBehaviour
{
    //CharacterController controller;
    public Rigidbody2D rb;
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

        var gamepad = Gamepad.current;
        if (gamepad != null) 
        {
            Vector2 movementinput = gamepad.leftStick.ReadValue();
            if (movementinput.x == 0 && movementinput.y == 0)
            {

            }
            else
            {
                direction = new Vector3(movementinput.x, movementinput.y, 0);
            }
        }
        
        _transform.position += (direction * Time.deltaTime * speed);
      
    }
}

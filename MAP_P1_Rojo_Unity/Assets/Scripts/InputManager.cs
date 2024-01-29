using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public Playermove _playermove; 
    // Start is called before the first frame update
    void Start()
    {
        
    }
    Vector2 direction = Vector2.zero;
    // Update is called once per frame
    void Update()
    {
         direction = Vector3.zero;

        if (Input.GetKey(KeyCode.UpArrow)) 
        {
        direction.y=1;
        }
      else  if (Input.GetKey(KeyCode.DownArrow))
        {
            direction.y = -1;
        }
       if (Input.GetKey(KeyCode.LeftArrow))
        {
            direction.x = -1;
        }
    else    if (Input.GetKey(KeyCode.RightArrow))
        {
            direction.x = 1;
        }
        _playermove.Changedirection(direction);
    }
}

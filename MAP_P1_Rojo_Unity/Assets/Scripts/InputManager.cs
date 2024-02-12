using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InputManager : MonoBehaviour
{
    public Playermove _playermove;
    public PlayerController controller;
    private bool canattack = false;
    public Animator animator;
    public GameObject imagenEspada;
    
  
    //para que pueda atacar cuando esté activo
    // Start is called before the first frame update
    void Start()
    {

    }
    Vector2 direction = Vector2.zero;
    // Update is called once per frame
    void Update()
    {
        direction = Vector3.zero;

        if (Input.GetKey(KeyCode.UpArrow)|| Input.GetKey(KeyCode.W))
        {
            direction.y = 1;
        }
        else if (Input.GetKey(KeyCode.DownArrow)|| Input.GetKey(KeyCode.S))
        {
            direction.y = -1;
        }
        else if (Input.GetKey(KeyCode.LeftArrow)||Input.GetKey(KeyCode.A))
        {
            direction.x = -1;
        }
        else if (Input.GetKey(KeyCode.RightArrow)|| Input.GetKey(KeyCode.D))
        {
            direction.x = 1;
            
        }
        _playermove.Changedirection(direction);
        /*if (Input.GetKeyDown(KeyCode.Z) && canattack == true)
        {
            controller.Attack();
           
        }*/

    }

    public void CanAttack()
    {
        animator.Play("CogerObjetos");
        
        if (imagenEspada != null)
            imagenEspada.SetActive(true);
    }
}

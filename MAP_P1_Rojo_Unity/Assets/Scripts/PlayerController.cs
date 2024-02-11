using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private int money, bombs, maxhealth, health;
    public GameObject ataqueArriba, ataqueAbajo, ataqueDerecha, ataqueIzquierda, proyectil, espadaUI;
    private AnimatorController animatorController;
    public bool canAttack;
    void Start()
    {
        money =bombs = 0;
        animatorController = GetComponent<AnimatorController>();
        maxhealth = health = 3;
    }
    public void AddMoney(int i) 
    {
        money += i;
        Debug.Log(money);
    }
    public void AddBomb()
    {
        bombs++;
        Debug.Log(bombs);
    }
    public void AddHealth() 
    {
    if (health < maxhealth) {  health ++; }
    }
    public void LooseHeath() 
    {
        health--;
        if (health == 0 ) 
        {
            Die();
        }
        animatorController.GetHit();
    }
    private void Die()
    {
        
    }
    public void Attack()
    {
        animatorController.ToAttack();
    }


    public void OnAtaque(InputAction.CallbackContext ctx) 
    {
        if (ctx.performed && canAttack==true)
        {
            Attack();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ToggleArriba()
    {
        ataqueArriba.SetActive(true);
        if (maxhealth == health)
        {
            GameObject espadaLanzada = Instantiate(proyectil, transform.position, Quaternion.Euler(0, 0, 0));
            espadaLanzada.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 5);
        }
        StartCoroutine(ResetHB(1));
    }   
    public void ToggleDeLado()
    {
        if (transform.rotation.eulerAngles.y == 0)
        {
            ataqueDerecha.SetActive(true);
            if (maxhealth == health)
            {
                GameObject espadaLanzada = Instantiate(proyectil, transform.position, Quaternion.Euler(0, 0, -90));
                espadaLanzada.GetComponent<Rigidbody2D>().velocity = new Vector2(5, 0);   
            }
            StartCoroutine(ResetHB(2));
        }
        else
        {
            ataqueIzquierda.SetActive(true);
            if (maxhealth == health)
            {
                GameObject espadaLanzada = Instantiate(proyectil, transform.position, Quaternion.Euler(0, 0, 90));
                espadaLanzada.GetComponent<Rigidbody2D>().velocity = new Vector2(-5, 0);
            }
            StartCoroutine(ResetHB(3));
        }
        
    }
    public void ToggleAbajo()
    {
        ataqueAbajo.SetActive(true);
        if (maxhealth==health)
        {
            GameObject espadaLanzada = Instantiate(proyectil, transform.position, Quaternion.Euler(0, 0, 180));
            espadaLanzada.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -5);
        }
        StartCoroutine(ResetHB(4));
    }

    IEnumerator ResetHB(int i)
    {
        yield return new WaitForFixedUpdate();
        yield return new WaitForFixedUpdate();
        yield return new WaitForFixedUpdate();
        
        if (i == 1)
        {
            ataqueArriba.SetActive(false);
        }
        else if (i == 2)
        {
            ataqueDerecha.SetActive(false);
        }
        else if (i == 3)
        {
            ataqueIzquierda.SetActive(false);
        }
        else
        {
            ataqueAbajo.SetActive(false);
        }
    }
    public void EnableAttack()
    {
        canAttack = true;
        animatorController.objectPickUp();
        espadaUI.SetActive(true);  
        
    }
        
}

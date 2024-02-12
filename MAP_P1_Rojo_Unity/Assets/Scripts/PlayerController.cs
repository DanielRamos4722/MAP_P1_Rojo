using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private int money, bombs, maxhealth, health;
    public GameObject ataqueArriba, ataqueAbajo, ataqueDerecha, ataqueIzquierda, proyectil, espadaUI;
    private AnimatorController animatorController;
    BoxCollider2D boxColl;
    public bool canAttack;
    public bool stateA = false;
    void Start()
    {
        money =bombs = 0;
        animatorController = GetComponent<AnimatorController>();
        maxhealth = health = 3;
        boxColl = GetComponent<BoxCollider2D>();
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
        VidaSystem vida = GetComponent<VidaSystem>();
    if (health < maxhealth) 
        {  
            health ++;
            vida.vida++;
        
        }
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
        StartCoroutine(AttackF());
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
            StartCoroutine(AttackF());
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
            StartCoroutine(AttackF());
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
        StartCoroutine(AttackF());
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
    IEnumerator AttackF()
    {
        stateA = true;
        yield return new WaitForSeconds(0.8f);
        boxColl.size = new Vector2(0.55f, 0.55f);
        stateA = false;
        boxColl.size = new Vector2(0.1f, 0.1f);
    }
    public void EnableAttack()
    {
        canAttack = true;
        animatorController.objectPickUp();
        espadaUI.SetActive(true);  
        
    }
        
}

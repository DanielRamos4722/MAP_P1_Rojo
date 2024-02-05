using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private int money, bombs, maxhealth, health;

    void Start()
    {
        money =bombs = 0;
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
    }
    private void Die()
    {
        
    }
    public void Attack()
    {
        maxhealth--;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

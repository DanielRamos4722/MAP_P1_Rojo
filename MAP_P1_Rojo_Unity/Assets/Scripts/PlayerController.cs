using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private int money;
    void Start()
    {
        money = 0;
    }
    public void AddMoney(int i) 
    {
        money += i;
        Debug.Log(money);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

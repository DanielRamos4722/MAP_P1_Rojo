using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private int money,bombs;
    void Start()
    {
        money =bombs = 0;
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

    // Update is called once per frame
    void Update()
    {
        
    }
}

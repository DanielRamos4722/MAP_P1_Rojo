using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    EnemyController enemyController;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        enemyController = collision.GetComponent<EnemyController>();
        if (enemyController != null) 
        {
            enemyController.Damaged();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

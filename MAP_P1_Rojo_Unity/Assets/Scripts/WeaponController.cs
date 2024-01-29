using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    EnemyController enemyController;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Detect");
        enemyController = collider.GetComponent<EnemyController>();
        if (enemyController != null) 
        {
            Debug.Log("Hit");
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

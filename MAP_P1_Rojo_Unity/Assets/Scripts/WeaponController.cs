using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
  
    EnemyController enemyController;
    PlayerController playerController;
    public int damage;
    private void OnTriggerEnter2D(Collider2D collider)
    {
           
    playerController = collider.GetComponent<PlayerController>();
        if (playerController != null)
        {
            playerController.EnableAttack();
            Destroy(gameObject);
        }
        enemyController = collider.GetComponent<EnemyController>();
        if (enemyController != null)
        {
            enemyController.Damaged(damage);
        }
    }
   
}

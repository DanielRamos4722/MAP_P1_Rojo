using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
  
    EnemyController enemyController;
    PlayerController playerController;
    InputManager inputManager;
    public int damage;

    private void Start()
    {
        inputManager = GameObject.Find("InputManager").GetComponent<InputManager>();
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        inputManager.CanAttack();

    
    playerController = collider.GetComponent<PlayerController>();
        if (playerController != null)
        {
            gameObject.SetActive(false);
            playerController.EnableAttack();
        }
        enemyController = collider.GetComponent<EnemyController>();
        if (enemyController != null)
        {
            enemyController.Damaged(damage);
        }
    }


   
}

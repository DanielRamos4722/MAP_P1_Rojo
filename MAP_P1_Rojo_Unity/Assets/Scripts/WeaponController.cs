using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    EnemyController enemyController;
   public InputManager inputManager;
    PlayerController playerController;
    private void OnTriggerEnter2D(Collider2D collider)
    {

        enemyController = collider.GetComponent<EnemyController>();
        if (enemyController != null)
        {

            Debug.Log("Hit");
            enemyController.Damaged();
        }
       
       
            playerController = collider.GetComponent<PlayerController>();
            if (playerController != null)
            {
                inputManager.CanAttack();
                Destroy(this.gameObject);
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

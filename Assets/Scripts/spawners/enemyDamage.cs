using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDamage : MonoBehaviour
{
    // Start is called before the first frame update
    public int damage;
    //public playerHealth playerHealth;
    
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Get the PlayerHealth script from the player and deal damage
            playerHealth playerHealth = collision.gameObject.GetComponent<playerHealth>();
            
            if (playerHealth != null)
            {
                playerHealth.playerHit(damage);
            }
        }
    }
}

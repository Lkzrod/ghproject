using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    private Player player;

    void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }
    // Start is called before the first frame update
     void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if(!player.invunerable){
            player.DamagePlayer();
            }
        }
            if (other.gameObject.CompareTag("Fall"))
        {
                player.Deathfall();   
        }
             if (other.gameObject.CompareTag("Exit"))
        {
                player.NextLevel();
            
        }
              if (other.gameObject.CompareTag("Bullet"))
        {
            
            player.DamagePlayer();
            
        }

    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : EnemyController
{

    public AudioClip fxGhost1;
        void Update()
        { 
                float distance = Vector2.Distance(transform.position,player.position);
                
                transform.position = Vector2.MoveTowards(transform.position,player.position, speedEnemy * Time.deltaTime);
               
                Flip();
                
                if (distance < lineOfSite)
                    {  
                    animEnemy.SetBool("Attack", true);
                    }else if (distance > lineOfSite)
                    {
                        animEnemy.SetBool("Attack", false);
                    }
                    
        }
        void FixedUpdate()
        {
                if (isMoving)
                {
                    rb2d.velocity = new Vector2(speedEnemy,rb2d.velocity.y);
                }

        }
            private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position,lineOfSite);
    }
}

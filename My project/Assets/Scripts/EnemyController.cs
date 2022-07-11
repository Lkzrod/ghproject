using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int Health;
    public float distanceAttack;
    public float lineOfSite;
    public float speedEnemy;
    public float retreatDistance;



    protected Rigidbody2D rb2d;
    protected Animator animEnemy;
    protected Transform player ;
    protected bool isMoving = false;
    
    protected SpriteRenderer sprite;
    

    void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
        rb2d = GameObject.Find("Ghost").GetComponent<Rigidbody2D>();
        animEnemy = GameObject.Find("Ghost").GetComponent<Animator>();
        sprite = GameObject.Find("Ghost").GetComponent<SpriteRenderer>();
    }
 
    public void Flip()
    {
        if (transform.position.x > player.transform.position.x)
        transform.rotation = Quaternion.Euler(0,0,0);
        else transform.rotation = Quaternion.Euler(0,180,0);
    }
    
}

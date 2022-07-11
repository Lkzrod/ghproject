using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RayGizmo : Player
{/*
    public LayerMask targetLayer;
    //[Range(.1f ,30)]
    public Transform directionRay;
    [SerializeField] float obstacleRayDistance;

    private Animator animEnemy;
    public Transform player;
    public Enemy enemy;


    private Animator animPlayer;

    public bool EnemyDetected {get; internal set;}

    void Start()
    {
        enemy = GameObject.Find("Ghost").GetComponent<Enemy>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        animEnemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Animator>();
        animPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
    } 
    // Update is called once per frame
     void Update()
    { 
        RaycastHit2D hit = Physics2D.Raycast (directionRay.transform.position, Vector3.left , obstacleRayDistance, targetLayer);
        if (hit.collider != null) 
        {
            if (Flashlight == true){
            Debug.DrawRay (directionRay.transform.position, Vector3.left * hit.distance , Color.red);
            Debug.Log("enemy detected");
            enemy.transform.position = Vector3.MoveTowards(enemy.transform.position,player.position, -enemy.speedEnemy * Time.deltaTime);
            }else if(Flashlight == false)
            {
            Debug.DrawRay (directionRay.transform.position, Vector3.left * obstacleRayDistance , Color.green);
            Debug.Log("no enemy detected");
            }
        }
    }
*/
}

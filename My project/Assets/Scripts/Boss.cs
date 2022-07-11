using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    public float speed;
    public float lineofSite;
    public float shootingRange;
    public float fireRate =1f;
    private float nextFireTime;
    public int bossH;
    
    public AudioClip bossDamage;
    private Player player1;

    public GameObject bullet;
    public GameObject bulletParent;
    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        bossH =4;
        player1 = GameObject.Find("Player").GetComponent<Player>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distancefromPlayer = Vector2.Distance(player.position, transform.position);
        if (distancefromPlayer < lineofSite && distancefromPlayer > shootingRange )
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.position,speed* Time.deltaTime);
        }else if (distancefromPlayer <= shootingRange && nextFireTime < Time.time)
        {
            Instantiate(bullet,bulletParent.transform.position,Quaternion.identity);
            nextFireTime = Time.time + fireRate;
        }
        if (transform.position.x > player.transform.position.x){
        transform.rotation = Quaternion.Euler(0,0,0);
        }
        else transform.rotation = Quaternion.Euler(0,180,0);
        if(bossH == 0){
            Destroy(gameObject);
            Invoke("EndGame",4f);
        }
        if (Input.GetButtonDown("Fire2") && GameManager.instance.battery == 6)
        {
            DamageBoss();
        }  
    }
    public void DamageBoss()
    {
        SoundManager.instance.PlayfxGhost(bossDamage);
        bossH --;
    }
    public void EndGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
     private void OnDrawGizmosSelected()
     {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position,lineofSite);
        Gizmos.DrawWireSphere(transform.position, shootingRange);

     }
}

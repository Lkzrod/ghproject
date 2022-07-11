using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
        public static Player instance;
    public float speed; // float = numeros quebrados
    public float radiusCheck;
    public float luxTime;
    public float lightTime;

    public bool invunerable = false;

    public int jumpForce; // int = numeros inteiros

    public Transform groundCheck;
    public Boss boss1;
    public GameObject Flashlight;
    public GameObject gLight;
    public GameObject arm;
    public GameObject ponte;
    public SpriteRenderer sprite;

    public LayerMask layerGround;

    public Animator animator;
    public AudioClip fxLantern;
    public AudioClip fxOffLantern;
    public AudioClip fxJump;
    public AudioClip fxHurt;
    public AudioClip fxGhost;

    
    public bool lantern;
    public bool gLux;
    public bool Grounded;
    private bool jumping;
    private bool isAlive = true;
    private bool facingRight = true;


    public Rigidbody2D rb2D;
   

 
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Boss boss1 = gameObject.GetComponent<Boss>();
        isAlive = true;
        sprite = GetComponent<SpriteRenderer>();
        ponte = GameObject.FindGameObjectWithTag("Ponte");
        rb2D = GetComponent<Rigidbody2D>();
        ponte.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive){
            if(lantern == true){
            lightTime = lightTime+Time.deltaTime;
                if (lightTime >=3f)
                {
                    GameManager.instance.battery--;
                    lightTime = 0f;
                    if(GameManager.instance.battery == 2)
                    {
                        SoundManager.instance.PlayfxPlayer(fxOffLantern);
                    }
                }
            }
            if(lantern == false)
            {
                lightTime = 0f;
            }
            if (Input.GetButtonDown("Fire1")&& GameManager.instance.battery > 0)
            {
                lantern=!lantern;
                if (lantern == true){
                    SoundManager.instance.PlayfxPlayer(fxLantern);
                    TurnOnLight();
                } else
                {
                    TurnOffLight();
                }
            }
            if (GameManager.instance.battery == 0)
            {
                lantern =false;
                TurnOffLight();
            }
            if(Input.GetButtonDown("Fire2")&& gLux == false && GameManager.instance.battery == 6)
            {         
            gLux=!gLux;
                if(gLux)
                { 
                    animator.SetBool("Lux",true);
                    invunerable = true;
                }
            }if (gLux && luxTime >= 0.8f)   
            {
                invunerable = false;
                LuxOn();
                animator.SetBool("Lux",false);

            }
        }if (gLux && luxTime >= 8f && GameManager.instance.battery < 6)
            {
                LuxOff();
            }
            Grounded = Physics2D.OverlapCircle (groundCheck.position, radiusCheck, layerGround);
          if (Input.GetButtonDown("Jump") && Grounded == true)
        {
            SoundManager.instance.PlayfxPlayer(fxJump);
           jumping = true; //comandos de pulo
        }
        ActiveObjects();  // atualizando sempre o chamado no void update.
         }
    
    void FixedUpdate()
    {
        if (isAlive)
        {
            float move = Input.GetAxis("Horizontal");
            rb2D.velocity= (new Vector2(move * speed, rb2D.velocity.y));
            animator.SetFloat("Speed", Mathf.Abs(move));
            if ((move <0 && facingRight) || (move > 0 && !facingRight))
                {
                    Flip();
             }

             if (jumping)   
                {
                    jumping = false;
                    rb2D.AddForce(new Vector2(0f,jumpForce));
                }
        if (gLux == true)
        {
            luxTime = luxTime+Time.deltaTime; // timer para desligar o Lux.
        }else
        {
            luxTime = 0f;
        }
        } else 
        {
            rb2D.velocity = new Vector2 (0, rb2D.velocity.y);
        }
    }
    void ActiveObjects()
    {
       if (Grounded == true)
        {
            animator.SetBool("Jumping", false);
            arm.SetActive(true);
        }
        if (Grounded && rb2D.velocity.x != 0)  
        {
            arm.SetActive(true);
        }
        else if (Grounded == false )
        {
            animator.SetBool("Jumping", true);
            arm.SetActive(false);
        }
        
    }
    // chamado para virar o personagem.
    void Flip()
    {
        facingRight = !facingRight;
        transform.localScale = new Vector3( -transform.localScale.x, transform.localScale.y, transform.localScale.z);
    } 
    // aqui é o chamado para ligar e desligar a lanterna.
    void TurnOnLight()
    {
    Flashlight.SetActive(true);
    ponte.SetActive(true);
    }
    void TurnOffLight()
    {
     Flashlight.SetActive(false);
     ponte.SetActive(false);
    }
    // aqui é o chamado para ligar ou desligar o power up Lux.
    private GameObject[] inimigos;

    public void LuxOn()
    {
        ponte.SetActive(true);
        gLight.SetActive(true);
        GameManager.instance.battery = 0;
       inimigos = GameObject.FindGameObjectsWithTag("Enemy");
       for(int i = 0; i <= inimigos.Length - 1; i++)
       {
         SoundManager.instance.PlayfxGhost(fxGhost);
         new WaitForSeconds(1.0f);
        Destroy(inimigos[i]);
       }
    }
    public void LuxOff()
    {
        gLight.SetActive(false);
        gLux = false;
        ponte.SetActive(false);
    }  

    IEnumerator Damage()
    {
        SoundManager.instance.PlayfxPlayer(fxHurt);
        for (float  i = 0f; i < 1f; i += 0.1f){
            sprite.enabled = false;
            yield return new WaitForSeconds (0.1f);
            sprite.enabled = true;
            yield return new WaitForSeconds (0.1f);

        }
        invunerable = false;
    }
    
    public void DamagePlayer()
    {
        if (isAlive){
        
        invunerable = true;
        GameManager.instance.health--;
        StartCoroutine(Damage());
         if (GameManager.instance.health < 1)
         {
            animator.SetTrigger("Hurt");
            arm.SetActive(false);
            isAlive = false;
            Invoke("ReloadLevel",4f);

         }
        }
    }
    public void Deathfall()
    {
        SoundManager.instance.PlayfxPlayer(fxHurt);
        Invoke("ReloadLevel",4f);
        GameManager.instance.health = 0;
        isAlive =false;
    }
    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void NextLevel()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}

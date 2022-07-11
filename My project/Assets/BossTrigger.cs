using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTrigger : MonoBehaviour
{
    public Boss boss;
    
    // Start is called before the first frame update
    void Start()
    {
        boss = GameObject.Find("Boss").GetComponent<Boss>();
    }

    // Update is called once per frame
    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.CompareTag("Boss"))
    {
            boss.DamageBoss();
    }
    }
}

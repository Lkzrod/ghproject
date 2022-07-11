using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBars : MonoBehaviour
{
    public static UIBars instance;
    public Sprite[] HBossbar;
    public Image healthBossBarUI;
    
    private Boss boss;
    // Start is called before the first frame update
    void Start()
    {
        boss = GameObject.Find("Boss").GetComponent<Boss>();
    }

    // Update is called once per frame
    void Update()
    {
        healthBossBarUI.sprite = HBossbar[boss.bossH];
    }
    
     
}


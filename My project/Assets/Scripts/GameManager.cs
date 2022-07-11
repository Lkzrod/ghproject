using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int health;
    public int battery;

    public enum GameStatus { WIN , DIE , PLAY}
    public GameStatus status;

    public Sprite[] Hbar;
    public Image healthBarUI;
    public Sprite[] Bbar;
    public Image batterybarUI;

    private Player player;
    // Start is called before the first frame update
    void Start()
    {
        
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        healthBarUI.sprite = Hbar[health];
        batterybarUI.sprite = Bbar[battery];
    }
    private int quantPilhas;
    void Awake() {
        if (instance == null)
        {
            instance = this;
        }else {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update

}

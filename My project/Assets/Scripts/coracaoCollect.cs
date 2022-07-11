using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coracaoCollect : MonoBehaviour
{
    public AudioClip fxCollect;
    // Start is called before the first frame update
 void OnTriggerEnter2D(Collider2D other)
 {
    if (other.CompareTag("Player"))
    {
        if(GameManager.instance.health<6){
        GameManager.instance.health++;
        SoundManager.instance.PlayfxCura(fxCollect);
        Destroy(gameObject);
        PlayerPrefs.SetInt("vida", GameManager.instance.health);
        }
    }
 }
}

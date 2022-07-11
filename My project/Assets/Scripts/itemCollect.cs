using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemCollect : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip fxCollect;
void OnTriggerEnter2D(Collider2D other)
 {
    if (other.CompareTag("Player"))
    {
        if(GameManager.instance.battery<6){
        GameManager.instance.battery++;
        SoundManager.instance.PlayfxItems(fxCollect);
        Destroy(gameObject);
        PlayerPrefs.SetInt("battery", GameManager.instance.battery);
    }
    }
 }
}

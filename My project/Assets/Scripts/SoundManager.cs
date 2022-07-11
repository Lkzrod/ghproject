using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public AudioSource fxPlayer;
    public AudioSource fxSounds;
    public AudioSource fxGhost;
    public AudioSource fxItems;
    public AudioSource fxCura;
    public AudioSource fxRun;

    void Awake (){
        if (instance == null){
        instance = this;
        }else{
        Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    public void PlayfxPlayer(AudioClip clip)
    {
        fxPlayer.clip = clip;
        fxPlayer.Play();
    }
    public void PlayfxItems(AudioClip clip)
    {
        fxItems.clip = clip;
        fxItems.Play();
    }
    public void PlayfxCura(AudioClip clip)
    {
        fxCura.clip = clip;
        fxCura.Play();
    }
    public void PlayfxGhost(AudioClip clip)
    {
        fxGhost.clip = clip;
        fxGhost.Play();
    }
    public void PlayfxSounds(AudioClip clip)
    {
        fxSounds.clip = clip;
        fxSounds.Play();
    }
}

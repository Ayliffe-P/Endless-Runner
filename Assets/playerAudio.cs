using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAudio : MonoBehaviour
{
    public AudioSource audio;
    public AudioClip coin;
    public AudioClip powerup;
    public AudioClip pad;
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public void playCoin() {
        audio.PlayOneShot(coin, 0.15f);
    }
    public void playPowerUp()
    {
        
        audio.PlayOneShot(powerup, 0.15f);
    }
    public void playPad()
    {

        audio.PlayOneShot(pad, 0.25f);
    }

    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource pearl;
    [SerializeField] AudioSource dolphin;
    [SerializeField] AudioSource finish;
    [SerializeField] AudioSource death;
    [SerializeField] AudioSource waveUp;
    [SerializeField] AudioSource bdmusicMenu;
    [SerializeField] AudioSource bdmusic; 
    [SerializeField] AudioSource bdMusicDive;
    [SerializeField] AudioSource gameOver;
    [SerializeField] AudioSource splash;
    [SerializeField] AudioSource buttonClick;

    public void pearlPlay()
    {
        pearl.Play();
    }

    public void dolphinPlay()
    {
        dolphin.Play();
    }

    public void finishPlay()
    {
        finish.Play();
    }

    public void deathPlay()
    {
        death.Play();
    }

    public void waveUpPlay()
    {
        waveUp.Play();
    }

    public void bdMusicMenuPlay() 
    {
        bdmusicMenu.Play();
    }

    public void bdMusicMenuMute()
    {
        bdmusicMenu.mute = true;
    }

    public void bdMusicMenuUnmute()
    {
        bdmusicMenu.mute = false;
    }

    public void bdPlay()
    {
        bdmusic.Play();
        DontDestroyOnLoad(this.gameObject);
    }

    public void bdMute() 
    {
        bdmusic.mute = true;
    }

    public void bdUnmute()
    {
        bdmusic.mute = false;
    }

    public void bdDivePlay()
    {
        bdMusicDive.Play();
        DontDestroyOnLoad(this.gameObject);
    }

    public void bdDiveMute()
    {
        bdMusicDive.mute = true;
    }

    public void bdDiveUnmute()
    {
        bdMusicDive.mute = false;
    }

    public void gameOverPlay() 
    {
        gameOver.Play();
    }

    public void splashPlay() 
    {
        splash.Play();
    }

    public void buttonClickPlay() 
    {
        buttonClick.Play();
    }
}

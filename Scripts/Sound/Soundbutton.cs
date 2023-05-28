using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Soundbutton : MonoBehaviour
{
    public AudioSource sceneMusic;
    public static bool musicOn = true;
    public GameObject tapedOff;
    public bool music1 = true;
    
    void Start()
    {
        GameObject music = GameObject.FindGameObjectWithTag("Music");
        if (music && music1)
            Destroy(music);
        if (musicOn)
        {
            tapedOff.SetActive(false);
            sceneMusic.mute = false;
        }
        else
        {
            sceneMusic.mute = true;
            tapedOff.SetActive(true);
        }
    }
    public void MusicButton()
    {
        
            musicOn = !musicOn;
           
    }
    void Update()
    {
        if (musicOn)
        {
            tapedOff.SetActive(false);
            sceneMusic.mute = false;
        }
        else
        {
            sceneMusic.mute = true;
            tapedOff.SetActive(true);
        }
        
    }
}

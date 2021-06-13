using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SoundUI : MonoBehaviour
{
    [SerializeField] private AudioSource musicManager;
    [SerializeField] private AudioSource soundManager;
    [SerializeField] private TMP_Text soundText;

    private bool soundOn = true;

    public void Click()
    {
        soundOn = !soundOn;
        musicManager.volume = soundOn ? 1f : 0f;
        soundManager.volume = soundOn ? 1f : 0f;
        if (soundOn)
        {
            soundText.text = "Sound on";
            soundText.alpha = 1f;
        }
        else
        {
            soundText.text = "Sound off";
            soundText.alpha = 0.7f;
        }
    }
    
    

}

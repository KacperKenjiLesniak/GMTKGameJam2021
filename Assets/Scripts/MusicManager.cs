using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{

    public List<AudioClip> audioClips;
        
    private static MusicManager instance;

    private AudioSource source;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else if(instance != this)
        {
            Destroy(this);
        }

        source = GetComponent<AudioSource>();
    }

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "Menu")
        {
            source.clip = audioClips[0];
            source.Play();
        }
    }

    public void PlayClip(int index)
    {
        source.clip = audioClips[index];
        source.Play();
    }
}

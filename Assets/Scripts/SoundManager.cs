using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public List<AudioClip> audioClips;

    public static SoundManager instance;

    private AudioSource source;

    private int recentlyPlayedClip = -1;
    
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else if (instance != this)
        {
            Destroy(this);
        }

        source = GetComponent<AudioSource>();
    }

    public void PlayClip(int index)
    {
        if (recentlyPlayedClip != index)
        {
            recentlyPlayedClip = index;
            source.PlayOneShot(audioClips[index]);
            CancelInvoke(nameof(ClearRecentlyPlayed));
            Invoke(nameof(ClearRecentlyPlayed), 0.1f);
        }
    }

    private void ClearRecentlyPlayed()
    {
        recentlyPlayedClip = -1;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    public void PlayTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }
    
    public void PlayGame()
    {
        SceneManager.LoadScene("Level1");
        MusicManager.instance.PlayClip(1);
    }

    public void PlayMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    
    public void PlayCredits()
    {
        SceneManager.LoadScene("Cred");
    }
    
    public void Continue()
    {
        SceneManager.LoadScene("Level" + PlayerPrefs.GetInt("NextLevel", 1));
    }
}

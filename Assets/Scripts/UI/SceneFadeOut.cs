using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneFadeOut : MonoBehaviour
{
    public string sceneName;
    public float fadeDelay;
    public float fadeSpeed;

    public Image image;

    private float fadeTimer;
    private bool fadeIn;
    private bool fadeOut;
    void Start()
    {
        fadeIn = true;
    }

    private void Update()
    {
        if (fadeIn)
        {
            FadeIn();
        }
        else if (fadeOut)
        {
            fadeTimer += Time.deltaTime;
            if (fadeTimer >= fadeDelay)
            {
                FadeOut();
            }
        }
    }

    public void FadeIn()
    {
        image.color = new Color(image.color.r, image.color.g, image.color.b,
            image.color.a - Time.deltaTime * fadeSpeed);
        if (image.color.a <= 0f)
        {
            fadeIn = false;
            fadeOut = true;
        }
    }
    
    public void FadeOut()
    {
        image.color = new Color(image.color.r, image.color.g, image.color.b,
            image.color.a + Time.deltaTime * fadeSpeed);
        if (image.color.a >= 1f)
        {
            SceneManager.LoadScene(sceneName);
        }
    }

}

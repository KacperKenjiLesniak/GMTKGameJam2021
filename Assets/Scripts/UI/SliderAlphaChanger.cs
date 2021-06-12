using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderAlphaChanger : MonoBehaviour
{
    [SerializeField] private Image background;
    [SerializeField] private Image handle;

    public void SetSelected(bool selected)
    {
        float newAlpha = selected ? 1.0f : 0.3f;

        background.color = new Color(background.color.r, background.color.g, background.color.b, newAlpha);
        handle.color = new Color(handle.color.r, handle.color.g, handle.color.b, newAlpha);
    }
}
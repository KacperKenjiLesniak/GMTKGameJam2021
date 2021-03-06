using System;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

public abstract class PhysicManipulator : MonoBehaviour
{
    public float minValue;
    public float maxValue;
    public float currentValue;
    public float changeSpeed;
    public Slider slider;
    
    private SliderAlphaChanger sliderAlphaChanger;

    private void Awake()
    {
        sliderAlphaChanger = slider.GetComponent<SliderAlphaChanger>();
    }

    protected virtual void Start()
    {
        slider.minValue = minValue;
        slider.maxValue = maxValue;
        slider.value = currentValue;
    }

    public void Scale(float modifier)
    {
        currentValue += modifier * Time.deltaTime * ( maxValue - minValue) * Constants.CHANGE_SPEED ;

        currentValue = Mathf.Clamp(currentValue, minValue, maxValue);

        slider.value = currentValue;

        UpdatePhysicProperty();
    }

    public void SetSelected(bool selected)
    {
        sliderAlphaChanger.SetSelected(selected);
    }
    
    protected abstract void UpdatePhysicProperty();
}
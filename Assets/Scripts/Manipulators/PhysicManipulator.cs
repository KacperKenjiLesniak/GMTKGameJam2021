using System;
using UnityEngine;
using UnityEngine.UI;

public abstract class PhysicManipulator : MonoBehaviour
{
    public float minValue;
    public float maxValue;
    public float currentValue;
    public float changeSpeed;
    public Slider slider;

    protected virtual void Start()
    {
        slider.minValue = minValue;
        slider.maxValue = maxValue;
        slider.value = currentValue;
    }

    public void Scale(float modifier)
    {
        currentValue += modifier * Time.deltaTime * changeSpeed;

        currentValue = Mathf.Clamp(currentValue, minValue, maxValue);

        slider.value = currentValue;

        UpdatePhysicProperty();
    }

    protected abstract void UpdatePhysicProperty();
}
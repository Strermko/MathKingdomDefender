using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderAnimation : MonoBehaviour
{
    // == Public params == //
    [Range(0f, 50f)]
    [SerializeField] float sliderSpeed = 1;
    // -- Private params -- //
    Slider slider;
    void Start()
    {
        slider = GetComponent<Slider>();
        Debug.Log(slider.value);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSliderValue(sliderSpeed);
    }

    private float UpdateSliderValue(float sliderSpeed)
    {
        slider.value -= Time.deltaTime * sliderSpeed;
        if(slider.value <= 1) slider.value = 100; 
        return slider.value;
    }
}

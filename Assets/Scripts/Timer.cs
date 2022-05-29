using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    private Slider slider;
    private float _velocity = 1;

    private void Start()
    {
        slider = gameObject.GetComponent<Slider>();
        ResetValue();
    }
    public void AddVelocity(float velocity){_velocity += velocity/10;}
    public void ResetValue(){_velocity = 1; slider.value = 100;}
    public bool SliderMovement(float speed)
    {
        slider.value -= Time.deltaTime * speed * _velocity;
        if(slider.value <= 0){slider.value = 100; return true;}
        return false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Observer : MonoBehaviour
{
    [SerializeField] List<GameObject> health; 
    [SerializeField] GameObject sliderObject;
    [Range(0f, 100f)] [SerializeField] float sliderSpeed = 10;

    [SerializeField] string answersTag;


    private Slider slider;
    private GameObject[] answerList;
    void Start()
    {
        slider = sliderObject.GetComponent<Slider>();
        answerList = GameObject.FindGameObjectsWithTag(answersTag);
        //answerList[2].GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "0";

    }

    void Update()
    {
        UpdateSliderValue(sliderSpeed);
    }

    private float UpdateSliderValue(float sliderSpeed)
    {
        slider.value -= Time.deltaTime * sliderSpeed;
        if(slider.value <= 1){
            slider.value = 100;
            if(health.Count > 0){
                Destroy(health[health.Count-1]);
                health.RemoveAt(health.Count -1);
            }
        } 
        return slider.value;
    }
}

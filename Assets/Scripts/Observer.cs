using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class Observer : MonoBehaviour
{
    [SerializeField] List<GameObject> health; 
    [SerializeField] GameObject sliderObject;
    [Range(0f, 100f)] [SerializeField] float sliderSpeed = 10;
    [SerializeField] GameObject[] answerList;
    [SerializeField] GameObject buttons;
    [SerializeField] string operationTag;
    [SerializeField] GameObject Points;


    private Slider slider;
    private int clickCounter;

    void Start()
    {
        slider = sliderObject.GetComponent<Slider>();
        clickCounter = 0;
    }

    void Update()
    {
        SliderMovement(sliderSpeed);
    }

    public void ClickEvent(){
        HandleButtonEvent();
        if (clickCounter == answerList.Length -1)
        {
            if(Operator.CheckAnswers(answerList, operationTag)) Operator.SetChildTextValue(Points, int.Parse(Operator.ReturnChildTextValue(Points)) + 50 + "");
            ResetFields();
            clickCounter = 0;
        }
        else {
            clickCounter += 1;
        }
    }

    private float SliderMovement(float sliderSpeed)
    {
        slider.value -= Time.deltaTime * sliderSpeed;
        if(slider.value <= 1){
            if(health.Count > 0){
                Destroy(health[health.Count-1]);
                health.RemoveAt(health.Count -1);
            }
            slider.value = 100;
        } 
        return slider.value;
    }

    private void ResetFields()
    {
        //Reset answer fields
        foreach (var item in answerList)
        {
            Operator.SetChildTextValue(item, "");
        }
        ResetButtonsValue();
        slider.value = 100;
    }

    private void HandleButtonEvent(){
        //Get clicked button and disable it
        GameObject usedButton = EventSystem.current.currentSelectedGameObject;
        usedButton.GetComponent<Button>().interactable = false;
        
        //Send value to answer field
        string value = Operator.ReturnChildTextValue(usedButton);
        Operator.SetChildTextValue(answerList[clickCounter], value);
    }

    private void ResetButtonsValue(){
        int counter = 0;
        var valueList = Operator.GenerateListOfValue();
        foreach (var item in buttons.GetComponentsInChildren<Button>())
        {
            Operator.SetChildTextValue(item.gameObject, valueList[counter] + "");
            if (item.interactable == false) item.interactable = true;
            counter+=1;
        }
    }


}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class Observer : MonoBehaviour
{
    [SerializeField] List<GameObject> health; 
    [Header("Slider")]
    [SerializeField] GameObject sliderObject;
    [Range(0f, 100f)] [SerializeField] float sliderSpeed = 10;
    [SerializeField] float sliderSpeedBoost;
    [Header("Answers Objects")]
    [SerializeField] GameObject[] answerList;
    [SerializeField] GameObject buttons;
    [SerializeField] GameObject execution;
    [Header("Points and feedbacks")]
    [SerializeField] GameObject Points;
    [Header("Particles")]
    [SerializeField] GameObject GoodAnswer;
    [SerializeField] GameObject BadAnswer;


    private Slider slider;
    private int clickCounter;
    private float defaultSliderSpeed;
    private SceneLoader sceneLoader;
    private TMPro.TextMeshProUGUI operation;
    private ParticleSystem goodAnswer;
    private ParticleSystem badAnswer;

    void Start()
    {
        StartConfiguration();
    }

    void Update()
    {
        SliderMovement(sliderSpeed);
    }

    private void StartConfiguration()
    {
        sceneLoader = GameObject.FindObjectOfType<SceneLoader>();
        defaultSliderSpeed = sliderSpeed;
        slider = sliderObject.GetComponent<Slider>();
        clickCounter = 0;
        operation = GameObject.FindGameObjectWithTag("Operation").GetComponent<TMPro.TextMeshProUGUI>();
        ResetFields();
        Operator.SetChildTextValue(Points, "0");
        goodAnswer = GoodAnswer.GetComponent<ParticleSystem>();
        badAnswer = BadAnswer.GetComponent<ParticleSystem>();
    }

    public void ClickEvent()
    {
        HandleButtonEvent();
        ChechAnswers();
    }

    private void ChechAnswers()
    {
        if (clickCounter == answerList.Length - 1)
        {
            if (Operator.CheckAnswers(answerList, execution)){
                Operator.SetChildTextValue(Points, int.Parse(Operator.ReturnChildTextValue(Points)) + 50 + "");
                goodAnswer.Play();
            } else {
                badAnswer.Play();
                DecreaseHealth();
                sliderSpeed = defaultSliderSpeed;
                if(health.Count <= 0) sceneLoader.LoadScene("GameOver");
            }
            ResetFields();
            clickCounter = 0;
        }
        else
        {
            clickCounter += 1;
        }
    }

    private float SliderMovement(float sliderSpeed)
    {
        slider.value -= Time.deltaTime * sliderSpeed;
        if(slider.value <= 1)
        {
            DecreaseHealth();
            slider.value = 100;
        }
        return slider.value;
    }

    private void DecreaseHealth()
    {
        if (health.Count > 0)
        {
            Destroy(health[health.Count - 1]);
            health.RemoveAt(health.Count - 1);
        }
    }

    private void ResetFields()
    {
        //Reset answer fields
        foreach (var item in answerList)
        {
            Operator.SetChildTextValue(item, "");
        }
        ResetButtonsValue();
        sliderSpeed += sliderSpeedBoost;
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
        //ListOfOperation.Plus;
        Operator.SetChildTextValue(execution, Operator.GetNewOperation(20));
    }


}
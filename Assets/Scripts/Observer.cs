using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class Observer : MonoBehaviour
{
    // Serialized object, for more clear code and separated scripts to pointed object
    [Header("Main Game Objects")]
    [SerializeField] GameObject Lifes;
    [SerializeField] GameObject Timer;
    [SerializeField] GameObject Answers;
    [Header("Parameters")]
    [Range(0f, 100f)] [SerializeField] float timerSpeed = 10;
    [SerializeField] float timerSpeedBoost;
    [SerializeField] GameObject[] answerList;
    [SerializeField] GameObject buttons;
    [SerializeField] GameObject execution;
    [SerializeField] GameObject Points;
    [SerializeField] GameObject GoodAnswer;
    [SerializeField] GameObject BadAnswer;


    private Lifes _lifes;
    private Timer _timer;
    private int clickCounter;
    private float defaultSliderSpeed;
    private SceneLoader sceneLoader;
    private TMPro.TextMeshProUGUI operation;
    private ParticleSystem goodAnswer;
    private ParticleSystem badAnswer;

    void Start(){StartConfiguration();}

    void Update()
    {
        Observe();
    }

    private void StartConfiguration()
    {
        // After refactoring
        _lifes = Lifes.GetComponent<Lifes>();
        _timer = Timer.GetComponent<Timer>();
        sceneLoader = GameObject.FindObjectOfType<SceneLoader>();
        // Before refactoring
        clickCounter = 0;
        operation = GameObject.FindGameObjectWithTag("Operation").GetComponent<TMPro.TextMeshProUGUI>();
        ResetFields();
        Operator.SetChildTextValue(Points, "0");
        goodAnswer = GoodAnswer.GetComponent<ParticleSystem>();
        badAnswer = BadAnswer.GetComponent<ParticleSystem>();
    }

    private void Observe()
    {
        if(_timer.SliderMovement(timerSpeed)){_lifes.RemoveHealth();}
        if(_lifes.IsDead()){sceneLoader.LoadScene("GameOver");}
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
                if(_lifes.IsDead()) sceneLoader.LoadScene("GameOver");
                _lifes.RemoveHealth();
            }
            ResetFields();
            clickCounter = 0;
        }
        else
        {
            clickCounter += 1;
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
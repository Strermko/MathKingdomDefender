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

    [SerializeField] string answersTag;
    [SerializeField] string buttonsTag;


    private Slider slider;
    private GameObject[] answerList;
    private GameObject buttons;
    private int clickCounter;
    void Start()
    {
        slider = sliderObject.GetComponent<Slider>();
        answerList = GameObject.FindGameObjectsWithTag(answersTag);
        buttons = GameObject.FindGameObjectWithTag(buttonsTag);
        clickCounter = 0;
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

    public void SendValue(){
        GameObject usedButton = EventSystem.current.currentSelectedGameObject;
        usedButton.GetComponent<Button>().interactable = false;
        
        string value = Operator.ReturnChildTextValue(usedButton);
        Operator.SetChildTextValue(answerList[clickCounter], value);
        if (clickCounter == answerList.Length -1){
            int a, b, c;
            a = int.Parse(Operator.ReturnChildTextValue(answerList[0]));
            b = int.Parse(Operator.ReturnChildTextValue(answerList[1]));
            c = int.Parse(Operator.ReturnChildTextValue(answerList[2]));
            string test = (a + b == c) ? "Good" : "Bad";
            Debug.Log(test);
            foreach (var item in answerList)
            {
                Operator.SetChildTextValue(item, "");
            }
            foreach (var item in buttons.GetComponentsInChildren<Button>())
            {
                if(item.interactable == false) item.interactable = true;
            }
            clickCounter = 0;
        } else {
            clickCounter += 1;
        }
    }
}

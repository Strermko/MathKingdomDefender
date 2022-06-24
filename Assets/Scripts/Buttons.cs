using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    public void ResetValues()
    {
        int counter = 0;
        var valueList = GenerateListOfValue();
        foreach (var item in GetComponentsInChildren<Button>())
        {
            Operator.SetChildTextValue(item.gameObject, valueList[counter] + "");
            if (item.interactable == false) item.interactable = true;
            counter += 1;
        }
    }

    public string ClickEvent()
    {
        //Get clicked button and disable it
        GameObject usedButton = EventSystem.current.currentSelectedGameObject;
        usedButton.GetComponent<Button>().interactable = false;
        return Operator.ReturnChildTextValue(usedButton);
    }

    private List<int> GenerateListOfValue(){
        List<int> values = new List<int>();
        while(values.Count < 10){
            int value = Random.Range(1,11);
            if(!values.Contains(value)) values.Add(value);
        }
        return values;
    }
}

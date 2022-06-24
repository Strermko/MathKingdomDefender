using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Answers : MonoBehaviour
{
    [SerializeField] GameObject[] boxList;
    [SerializeField] GameObject execution;

    private void Start()
    {
        ResetValues();
    }

    public bool CheckAnswers()
    {
        string operation = Operator.ReturnChildTextValue(execution);
        //Get params from answer fields
        int a, b, c;
        a = int.Parse(boxList[0].GetComponentInChildren<TMPro.TextMeshProUGUI>().text);
        b = int.Parse(boxList[1].GetComponentInChildren<TMPro.TextMeshProUGUI>().text);
        c = int.Parse(boxList[2].GetComponentInChildren<TMPro.TextMeshProUGUI>().text);
        //Calculate and return value
        switch (operation)
        {
            case "+":
                if (a + b == c) return true;
                return false;
            case "-":
                if (a - b == c) return true;
                return false;
            case "*":
                if (a * b == c) return true;
                return false;
            case "/" or ":":
                if (a / b == c) return true;
                return false;
            default:
                return false;
        }
    }

    public void ResetValues()
    {
        foreach (var box in boxList) Operator.SetChildTextValue(box, "");
        SetExecution();
    }

    public void SetBoxValue(int counter, string value) { Operator.SetChildTextValue(boxList[counter], value); }

    public string GetExecution() { return Operator.ReturnChildTextValue(execution); }
    public void SetExecution() {Operator.SetChildTextValue(execution, GetNewExecution());}
    public void SetExecution(string value) { Operator.SetChildTextValue(execution, value); }
    public void SetExecution(int range) {Operator.SetChildTextValue(execution, GetNewExecution(range));}
    public string GetNewExecution(int range = 20)
    {
        string operation = "+";
        int number = Random.Range(0, range);
        if (number <= 40) operation = "*";
        if (number <= 30) operation = ":";
        if (number <= 20) operation = "-";
        if (number <= 10) operation = "+";
        return operation;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Operator
{
    public static void SetChildTextValue(GameObject gameObject, string value){
        gameObject.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = value;
    }
    public static void SetChildTextValue(GameObject gameObject, char value){
        gameObject.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "" + value;
    }

    public static string ReturnChildTextValue(GameObject gameObject){
        return gameObject.GetComponentInChildren<TMPro.TextMeshProUGUI>().text;
    }

    public static bool CheckAnswers(GameObject[] gameObjects, GameObject execution){
        bool answ = false;
        //Get params from answer fields
        int a, b, c;
        a = int.Parse(gameObjects[0].GetComponentInChildren<TMPro.TextMeshProUGUI>().text);
        b = int.Parse(gameObjects[1].GetComponentInChildren<TMPro.TextMeshProUGUI>().text);
        c = int.Parse(gameObjects[2].GetComponentInChildren<TMPro.TextMeshProUGUI>().text);
        //Get operation value
        string operation = ReturnChildTextValue(execution);
        //Calculate and return value
        switch(operation){
            case "+":
                if(a + b == c) answ = true;
                break;
            case "-":
                if(a - b == c) answ = true;
                break;
            case "*":
                if(a * b == c) answ = true;
                break;
            case "/" or ":":
                if(a / b == c) answ = true;
                break;
            default:
                break;
        }
        return answ;
    }

    public static List<int> GenerateListOfValue(){
        List<int> values = new List<int>();
        while(values.Count < 10){
            int value = Random.Range(1,11);
            if(!values.Contains(value)) values.Add(value);
        }
        return values;
    }

    public static char GetNewOperation(int range = 20){
        char operation = '+';
        int number = Random.Range(0,range);
        if(number <= 40) operation = '*';
        if(number <= 30) operation = ':';
        if(number <= 20) operation = '-';
        if(number <= 10) operation = '+';
        return operation;
    }
}

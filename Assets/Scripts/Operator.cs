using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Operator
{
    public static void SetChildTextValue(GameObject gameObject, string value){
        gameObject.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = value;
    }

    public static string ReturnChildTextValue(GameObject gameObject){
        return gameObject.GetComponentInChildren<TMPro.TextMeshProUGUI>().text;
    }

    public static bool CheckAnswers(GameObject[] gameObjects, string operation){
        bool answ = false;
        int a, b, c;
        a = int.Parse(gameObjects[0].GetComponentInChildren<TMPro.TextMeshProUGUI>().text);
        b = int.Parse(gameObjects[1].GetComponentInChildren<TMPro.TextMeshProUGUI>().text);
        c = int.Parse(gameObjects[2].GetComponentInChildren<TMPro.TextMeshProUGUI>().text);
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
            case "/":
                if(a / b == c) answ = true;
                break;
            default:
                break;
        }
        return answ;
    }

}

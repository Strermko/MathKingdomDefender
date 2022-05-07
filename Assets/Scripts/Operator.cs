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

}

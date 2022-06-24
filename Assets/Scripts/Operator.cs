using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Operator
{
    /// Work with different input params ///
    public static void SetChildTextValue(GameObject gameObject, string value){
        gameObject.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = value;
    }

    public static void SetChildTextValue(GameObject gameObject, char value){
        gameObject.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "" + value;
    }
    
    public static void SetChildTextValue(GameObject gameObject, int value){
        gameObject.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "" + value;
    }

    public static string ReturnChildTextValue(GameObject gameObject){
        return gameObject.GetComponentInChildren<TMPro.TextMeshProUGUI>().text;
    }
}

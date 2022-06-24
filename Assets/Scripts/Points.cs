using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
    [SerializeField] GameObject value;

    public int ReturnValue() { return int.Parse(Operator.ReturnChildTextValue(value)); }
    public void SetValue(int points) { Operator.SetChildTextValue(value, points); }
    public void IncreaseValue(int points) { SetValue(ReturnValue() + points); }
    public void DecreaseValue(int points) { SetValue(ReturnValue() - points); }
}

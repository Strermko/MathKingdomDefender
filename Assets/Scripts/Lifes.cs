using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifes : MonoBehaviour
{
    [SerializeField] Sprite FullHearth;
    [SerializeField] Sprite EmptyHearth;
    [SerializeField] List<GameObject> Healths;

    private int _lifes;

    private void Start()
    {
        _lifes = Healths.Count - 1;
    }
    public void RemoveHealth()
    {
        Healths[_lifes].GetComponent<SpriteRenderer>().sprite = EmptyHearth;
        _lifes -= 1;
    }
    public bool IsDead()
    {   
        if(_lifes < 0){return true;}
        else{return false;}
    }
}

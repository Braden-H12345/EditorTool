using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class DataHolder : MonoBehaviour
{
    //this simply holds the data on the Character
    [SerializeField] public GeneralData _characterInfo;

    private string _abilityOneName;
    private string _abilityTwoName;
    private string _abilityThreeName;
    private string _abilityFourName;

    private void Start()
    {
        _abilityOneName = _characterInfo._abilityOne._abilityName;
        _abilityTwoName = _characterInfo._abilityTwo._abilityName;
        _abilityThreeName = _characterInfo._abilityThree._abilityName;
        _abilityFourName = _characterInfo._abilityFour._abilityName;

        //removes spaces from the name to allow for adding of componenets
        _abilityOneName = _abilityOneName.Replace(" ", "");
        _abilityTwoName = _abilityTwoName.Replace(" ", "");
        _abilityThreeName = _abilityThreeName.Replace(" ", "");
        _abilityFourName = _abilityFourName.Replace(" ", "");

        //debug testing that it works
        //Debug.Log(_abilityOneName);
        //Debug.Log(_abilityTwoName); Debug.Log(_abilityThreeName); Debug.Log(_abilityFourName);

        gameObject.AddComponent(Type.GetType(_abilityOneName));
        gameObject.AddComponent(Type.GetType(_abilityTwoName));
        gameObject.AddComponent(Type.GetType(_abilityThreeName));
        gameObject.AddComponent(Type.GetType(_abilityFourName));
    }
}

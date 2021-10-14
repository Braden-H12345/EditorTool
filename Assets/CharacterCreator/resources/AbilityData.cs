using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AbilityData : ScriptableObject
{
    [SerializeField] public string _abilityName;
    [SerializeField] string _description;
    [SerializeField] float _cost;
    [SerializeField] float _cooldown;
    [SerializeField] KeyCode _keyToUse;
}

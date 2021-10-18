using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CharacterTypes;


public class AbilityData : ScriptableObject
{
    [SerializeField] public AbilityTypes _abilityType;
    [SerializeField] public string _abilityName;
    [SerializeField] public string _description;
    [SerializeField] public float _cooldown;
    [SerializeField] public KeyCode _keyToUse;
}

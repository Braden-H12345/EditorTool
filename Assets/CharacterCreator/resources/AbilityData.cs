using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AbilityData : ScriptableObject
{
    [SerializeField] string _abilityName;
    [SerializeField] string _description;
    [SerializeField] float _cost;
    [SerializeField] float _cooldown;
}

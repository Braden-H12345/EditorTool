using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CharacterTypes;

[CreateAssetMenu(fileName = "New Character", menuName = "New Character")]
public class GeneralData : ScriptableObject
{
    [SerializeField] public string _name;
    //Characters can be different races such as Orc, Elf, Human etc.

    [SerializeField] public RaceTypes _race;

    [SerializeField] public AbilityData _abilityOne;
    [SerializeField] public AbilityData _abilityTwo;
    [SerializeField] public AbilityData _abilityThree;
    [SerializeField] public AbilityData _abilityFour;
}

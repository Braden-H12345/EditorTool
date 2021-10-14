using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "New Character")]
public class GeneralData : ScriptableObject
{
    [SerializeField] string _name;
    //Characters can be different races such as Orc, Elf, Human etc.
    [SerializeField] string _raceType;
    [SerializeField] [Range(0, 10)] int _strength;
    [SerializeField] [Range(0, 10)] int _magic;
    [SerializeField] [Range(0, 10)] int _stamina;
    [SerializeField] [Range(0, 10)] int _luck;
    [SerializeField] [Range(0, 10)] int _charisma;
}

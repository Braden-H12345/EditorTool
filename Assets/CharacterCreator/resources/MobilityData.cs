using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Mobility Ability", menuName = "Abilities/Mobility")]
public class MobilityData : AbilityData
{
    [SerializeField] public float _maxDistance;
    [SerializeField] public float _speed;
}

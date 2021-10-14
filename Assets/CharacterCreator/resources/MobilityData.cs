using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Mobility Ability", menuName = "Abilities/Mobility")]
public class MobilityData : AbilityData
{
    [SerializeField] float _maxDistance;
    [SerializeField] float _speed;
}

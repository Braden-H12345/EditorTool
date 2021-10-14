using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New AOE Ability", menuName = "Abilities/AOE")]
public class AOEAbilityData : AbilityData
{
    [SerializeField] float _radius;
    
    [Header("Used for damage or heal amount... if ability will damage or heal")]
    [SerializeField] float _effectAmount;
}

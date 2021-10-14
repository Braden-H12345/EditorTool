using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Targeted Ability", menuName = "Abilities/Targeted")]
public class TargetedAbilityData : AbilityData
{
    [Header("Used for damage or heal amount... if ability will damage or heal")]
    [SerializeField] float _effectAmount;

    [SerializeField] bool _canTargetAllies = false;
    [SerializeField] bool _canTargetEnemies = false;
}

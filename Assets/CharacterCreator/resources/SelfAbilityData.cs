using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Self Buff Ability", menuName = "Abilities/Self Buff")]
public class SelfAbilityData : AbilityData
{
    [SerializeField] public float _duration;
}

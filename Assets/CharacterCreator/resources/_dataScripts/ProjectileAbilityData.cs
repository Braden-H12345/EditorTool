using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Projectile Ability", menuName = "Abilities/Projectile")]
public class ProjectileAbilityData: AbilityData
{

    [Header("Used for damage or heal amount... if ability will damage or heal")]
    [SerializeField] public float _effectAmount;
    [SerializeField] public Rigidbody _projectile;
    [SerializeField] public float _range;
}

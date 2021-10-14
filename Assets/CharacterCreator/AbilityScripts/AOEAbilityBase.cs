using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AOEAbilityBase : MonoBehaviour, IAbility
{
    public virtual void Cast(float radius, float effectAmount, float duration)
    {

    }
}

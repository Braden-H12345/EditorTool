using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAbility
{
    void Cast(float radius, float effectAmount, float duration);
}

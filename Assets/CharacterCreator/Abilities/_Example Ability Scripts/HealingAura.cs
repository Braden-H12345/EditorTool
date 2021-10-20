using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingAura : MonoBehaviour, IAbility
{
    private AbilityData _abilityToUse;
    // Start is called before the first frame update
    void Start()
    {
        FindAbility();
    }

    // Update is called once per frame
    void Update()
    {
        if(_abilityToUse != null)
        {
            if(Input.GetKeyDown(_abilityToUse._keyToUse))
            {
                Debug.Log("Healing Aura!");
                //you would also call cast here!


            }
        }
    }

    public void Cast(float radius, float effectAmount, float duration)
    {
        

        
    }

    string FindAbility()
    {
        GeneralData _finder = GetComponent<DataHolder>()._characterInfo;

        string _abilityName = "";

        for(int i=0;i<5;i++)
        {
            if(i == 0)
            {
                _abilityName = _finder._abilityOne._abilityName;
                _abilityName = _abilityName.Replace(" ", "");
                _abilityToUse = _finder._abilityOne;
            }
            if (i == 1)
            {
                _abilityName = _finder._abilityTwo._abilityName;
                _abilityName = _abilityName.Replace(" ", "");
                _abilityToUse = _finder._abilityTwo;
            }
            if (i == 2)
            {
                _abilityName = _finder._abilityThree._abilityName;
                _abilityName = _abilityName.Replace(" ", "");
                _abilityToUse = _finder._abilityThree;
            }
            if (i == 3)
            {
                _abilityName = _finder._abilityFour._abilityName;
                _abilityName = _abilityName.Replace(" ", "");
                _abilityToUse = _finder._abilityFour;
            }
            if (_abilityName.Equals(this.GetType().Name))
                {
                break;
                }
        }
        return _abilityName;
    }
}

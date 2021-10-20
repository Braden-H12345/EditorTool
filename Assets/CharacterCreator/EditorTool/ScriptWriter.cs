using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using CharacterTypes;
public static class ScriptWriter
{
    public static void Write(string _abilityName, AbilityTypes _type)
    {
        string _find = " ";
        string _replace = "";

        string _pathToScriptLocation = "Assets/CharacterCreator/Abilities";
        _abilityName = _abilityName.Replace(_find, _replace);

        switch (_type)
        {
            case AbilityTypes.AOE:
                _pathToScriptLocation += "/AOE/";
                break;
            case AbilityTypes.MOBILITY:
                _pathToScriptLocation += "/Mobility/";
                break;
            case AbilityTypes.PROJECTILE:
                _pathToScriptLocation += "/Projectile/";
                break;
            case AbilityTypes.SELFBUFF:
                _pathToScriptLocation += "/Selfbuff/";
                break;
        }

        _pathToScriptLocation += _abilityName + ".cs";
        try
        {
            if (File.Exists(_pathToScriptLocation))
            {
                Debug.LogWarning("File: " + _abilityName + ".cs" + "already exists");
            }
            else
            {


                StreamWriter sw = new StreamWriter(_pathToScriptLocation);

                sw.WriteLine("using System.Collections;");
                sw.WriteLine("using System.Collections.Generic;");
                sw.WriteLine("using UnityEngine;");
                sw.WriteLine();
                sw.WriteLine("public class " + _abilityName + " : MonoBehaviour, IAbility");
                sw.WriteLine("{");
                sw.WriteLine();
                sw.WriteLine("void Start()");
                sw.WriteLine("{");
                sw.WriteLine();
                sw.WriteLine("}");
                sw.WriteLine();
                sw.WriteLine("void Update()");
                sw.WriteLine("{");
                sw.WriteLine();
                sw.WriteLine("}");
                sw.WriteLine();
                sw.WriteLine("public void Cast(float radius, float effectAmount, float duration)");
                sw.WriteLine("{");
                sw.WriteLine();
                sw.WriteLine("}");
                sw.WriteLine();
                sw.WriteLine("}");

                sw.Close();



            }
        }
        catch (DirectoryNotFoundException e)
        {
            Debug.LogWarning("Directory likely changed... Visit 'ScriptWriter.cs' to change some directory paths");
            Debug.LogException(e);
        }
        
    }
}

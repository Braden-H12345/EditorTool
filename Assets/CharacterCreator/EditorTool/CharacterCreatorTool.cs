using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CharacterTypes;

public class CharacterCreatorTool : EditorWindow
{
    Texture2D _headerTexture;
    Texture2D _bodyTexture;

    Color _headerColor = new Color(0.6033731f, 0.8584906f, 0.8327252f, 1f);
    Color _bodyColor = new Color(0.6509434f, 0.5434763f, 0.6356393f, 1f);
    Rect _headerRect;
    Rect _bodyRect;

    static GeneralData _charData;
    static AbilityData _abilityOne;
    static AbilityData _abilityTwo;
    static AbilityData _abilityThree;
    static AbilityData _abilityFour;


    public static GeneralData CharacterInfo
    {
        get
        {
            return _charData;
        }
    }    
    public static AbilityData AbilityOneInfo
    {
        get
        {
            return _abilityOne;
        }
    }

    public static AbilityData AbilityTwoInfo
    {
        get
        {
            return _abilityTwo;
        }
    }

    public static AbilityData AbilityThreeInfo
    {
        get
        {
            return _abilityThree;
        }
    }

    public static AbilityData AbilityFourInfo
    {
        get
        {
            return _abilityFour;
        }
    }


    [MenuItem("Window/Character Creator")]
    static void OpenWindow()
    {
        CharacterCreatorTool window = (CharacterCreatorTool)GetWindow(typeof(CharacterCreatorTool));
        window.minSize = new Vector2(600, 600);
        window.Show();
    }

    void OnEnable()
    {
        InitTextures();
        InitData();
    }

    public static void InitData()
    {
        _charData = (GeneralData)ScriptableObject.CreateInstance(typeof(GeneralData));
        _abilityOne = (AbilityData)ScriptableObject.CreateInstance(typeof(AbilityData));
        _abilityTwo = (AbilityData)ScriptableObject.CreateInstance(typeof(AbilityData));
        _abilityThree = (AbilityData)ScriptableObject.CreateInstance(typeof(AbilityData));
        _abilityFour = (AbilityData)ScriptableObject.CreateInstance(typeof(AbilityData));
    }
    void InitTextures()
    {
        _headerTexture = new Texture2D(1, 1);
        _headerTexture.SetPixel(0, 0, _headerColor);
        _headerTexture.Apply();

        _bodyTexture = new Texture2D(1, 1);
        _bodyTexture.SetPixel(0, 0, _bodyColor);
        _bodyTexture.Apply();
    }
    void OnGUI()
    {
        DrawLayouts();
        DrawHeader();
        DrawGeneralSettings();
    }

    void DrawLayouts()
    {
        _headerRect.x = 0;
        _headerRect.y = 0;
        _headerRect.width = Screen.width;
        _headerRect.height = 50;

        _bodyRect.x = 0;
        _bodyRect.y = 50;
        _bodyRect.width = Screen.width;
        _bodyRect.height = Screen.height - 50;

        GUI.DrawTexture(_headerRect, _headerTexture);
        GUI.DrawTexture(_bodyRect, _bodyTexture);
    }

    void DrawHeader()
    {
        GUILayout.BeginArea(_headerRect);
        GUI.Label(new Rect(Screen.width * .4f, 25, 200, 30), "Character Creator");
        GUILayout.EndArea();
    }

    void DrawGeneralSettings()
    {
        GUILayout.BeginArea(_bodyRect);
        GUILayout.BeginVertical();
        GUILayout.BeginHorizontal();
        GUILayout.Label("Name");
        _charData._name = GUILayout.TextField(_charData._name);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Race");
        _charData._race = (RaceTypes)EditorGUILayout.EnumPopup(_charData._race);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Ability 1 Type:");
        _abilityOne._abilityType = (AbilityTypes)EditorGUILayout.EnumPopup(_abilityOne._abilityType);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Ability 2 Type:");
        _abilityTwo._abilityType = (AbilityTypes)EditorGUILayout.EnumPopup(_abilityTwo._abilityType);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Ability 3 Type:");
        _abilityThree._abilityType = (AbilityTypes)EditorGUILayout.EnumPopup(_abilityThree._abilityType);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Ability 4 Type:");
        _abilityFour._abilityType = (AbilityTypes)EditorGUILayout.EnumPopup(_abilityFour._abilityType);
        GUILayout.EndHorizontal();


        if (_charData._name == null || _charData._name.Length < 1)
        {
            EditorGUILayout.HelpBox("Character Needs a name before abilities can be created!", MessageType.Info);
        }
        else if(GUILayout.Button("Create Abilities", GUILayout.Height(40)))
        {
            AbilityTypes[] types = new AbilityTypes[4];
            types[0] = _abilityOne._abilityType;
            types[1] = _abilityTwo._abilityType;
            types[2] = _abilityThree._abilityType;
            types[3] = _abilityFour._abilityType;

            AbilitySettings.OpenWindow(types);
            
        }
        GUILayout.EndVertical();
        GUILayout.EndArea();
    }
}

public class AbilitySettings : EditorWindow
{
    static AbilityTypes _abilityOneSetting;
    static AbilityTypes _abilityTwoSetting;
    static AbilityTypes _abilityThreeSetting;
    static AbilityTypes _abilityFourSetting;

    static AOEAbilityData _AOEData;
    static AOEAbilityData _AOEDataTwo;
    static AOEAbilityData _AOEDataThree;
    static AOEAbilityData _AOEDataFour;

    static ProjectileAbilityData _projData;
    static ProjectileAbilityData _projDataTwo;
    static ProjectileAbilityData _projDataThree;
    static ProjectileAbilityData _projDataFour;

    static SelfAbilityData _selfData;
    static SelfAbilityData _selfDataTwo;
    static SelfAbilityData _selfDataThree;
    static SelfAbilityData _selfDataFour;

    static MobilityData _mobileData;
    static MobilityData _mobileDataTwo;
    static MobilityData _mobileDataThree;
    static MobilityData _mobileDataFour;

    static GeneralData _characterToMake;

    Rect _abilityOneRect;
    Rect _abilityTwoRect;
    Rect _abilityThreeRect;
    Rect _abilityFourRect;

    static AbilitySettings window;

    bool _oneBool = false;
    bool _twoBool = false;
    bool _threeBool = false;
    bool _fourBool = false;

    public static void OpenWindow(AbilityTypes[] typesArr)
    {
        _abilityOneSetting = typesArr[0];
        _abilityTwoSetting = typesArr[1];
        _abilityThreeSetting = typesArr[2];
        _abilityFourSetting = typesArr[3];

        window = (AbilitySettings)GetWindow(typeof(AbilitySettings));
        window.minSize = new Vector2(300, 450);
        window.Show();
    }


    void OnEnable()
    {
        InitData();
    }

    public static void InitData()
    {
        _AOEData = (AOEAbilityData)ScriptableObject.CreateInstance(typeof(AOEAbilityData));
        _AOEDataTwo = (AOEAbilityData)ScriptableObject.CreateInstance(typeof(AOEAbilityData));
        _AOEDataThree = (AOEAbilityData)ScriptableObject.CreateInstance(typeof(AOEAbilityData));
        _AOEDataFour = (AOEAbilityData)ScriptableObject.CreateInstance(typeof(AOEAbilityData));

        _mobileData = (MobilityData)ScriptableObject.CreateInstance(typeof(MobilityData));
        _mobileDataTwo = (MobilityData)ScriptableObject.CreateInstance(typeof(MobilityData));
        _mobileDataThree = (MobilityData)ScriptableObject.CreateInstance(typeof(MobilityData));
        _mobileDataFour = (MobilityData)ScriptableObject.CreateInstance(typeof(MobilityData));

        _projData = (ProjectileAbilityData)ScriptableObject.CreateInstance(typeof(ProjectileAbilityData));
        _projDataTwo = (ProjectileAbilityData)ScriptableObject.CreateInstance(typeof(ProjectileAbilityData));
        _projDataThree = (ProjectileAbilityData)ScriptableObject.CreateInstance(typeof(ProjectileAbilityData));
        _projDataFour = (ProjectileAbilityData)ScriptableObject.CreateInstance(typeof(ProjectileAbilityData));

        _selfData = (SelfAbilityData)ScriptableObject.CreateInstance(typeof(SelfAbilityData));
        _selfDataTwo = (SelfAbilityData)ScriptableObject.CreateInstance(typeof(SelfAbilityData));
        _selfDataThree = (SelfAbilityData)ScriptableObject.CreateInstance(typeof(SelfAbilityData));
        _selfDataFour = (SelfAbilityData)ScriptableObject.CreateInstance(typeof(SelfAbilityData));

        _characterToMake = (GeneralData)ScriptableObject.CreateInstance(typeof(GeneralData));

    }

    private void OnGUI()
    {
        DrawLayouts();
        DrawAbilitySettings();
    }

    void DrawLayouts()
    {
        _abilityOneRect.x = 0;
        _abilityOneRect.y = 0;
        _abilityOneRect.width = Screen.width / 4;
        _abilityOneRect.height = Screen.height;

        _abilityTwoRect.x = Screen.width / 4;
        _abilityTwoRect.y = 0;
        _abilityTwoRect.width = Screen.width / 4;
        _abilityTwoRect.height = Screen.height;

        _abilityThreeRect.x = Screen.width / 2;
        _abilityThreeRect.y = 0;
        _abilityThreeRect.width = Screen.width / 4;
        _abilityThreeRect.height = Screen.height;

        _abilityFourRect.x = Screen.width - (Screen.width /4);
        _abilityFourRect.y = 0;
        _abilityFourRect.width = Screen.width / 4;
        _abilityFourRect.height = Screen.height;
    }

    void DrawAbilitySettings()
    {
        GUILayout.BeginArea(_abilityOneRect);
        switch(_abilityOneSetting)
        {
            case AbilityTypes.AOE:
                _AOEData._abilityType = AbilityTypes.AOE;
                DrawAOE(_AOEData, "One");
                if (_AOEData._abilityName == null || _AOEData._abilityName.Length < 1)
                {
                    EditorGUILayout.HelpBox("Each Ability needs a name before it can be created!", MessageType.Info);
                }
                else
                {
                    _oneBool = true;
                }
                break;


            case AbilityTypes.MOBILITY:
                _mobileData._abilityType = AbilityTypes.MOBILITY;
                DrawMobility(_mobileData, "One");
                if (_mobileData._abilityName == null || _mobileData._abilityName.Length < 1)
                {
                    EditorGUILayout.HelpBox("Each Ability needs a name before it can be created!", MessageType.Info);
                }
                else
                {
                    _oneBool = true;
                }
                break;


            case AbilityTypes.SELFBUFF:
                _selfData._abilityType = AbilityTypes.SELFBUFF;
                DrawSelfBuff(_selfData, "One");
                if (_selfData._abilityName == null || _selfData._abilityName.Length < 1)
                {
                    EditorGUILayout.HelpBox("Each Ability needs a name before it can be created!", MessageType.Info);
                }
                else
                {
                    _oneBool = true;
                }
                break;


            case AbilityTypes.PROJECTILE:
                _projData._abilityType = AbilityTypes.PROJECTILE;
                DrawProjectile(_projData, "One");
                if (_projData._abilityName == null || _projData._abilityName.Length < 1)
                {
                    EditorGUILayout.HelpBox("Each Ability needs a name before it can be created!", MessageType.Info);
                }
                else
                {
                    _oneBool = true;
                }
                break;
        }
        GUILayout.EndArea();

        GUILayout.BeginArea(_abilityTwoRect);
        switch (_abilityTwoSetting)
        {


            case AbilityTypes.AOE:
                _AOEDataTwo._abilityType = AbilityTypes.AOE;
                DrawAOE(_AOEDataTwo, "Two");
                if (_AOEDataTwo._abilityName == null || _AOEDataTwo._abilityName.Length < 1)
                {
                    EditorGUILayout.HelpBox("Each Ability needs a name before it can be created!", MessageType.Info);
                }
                else
                {
                    _twoBool = true;
                }
                break;


            case AbilityTypes.MOBILITY:
                _mobileDataTwo._abilityType = AbilityTypes.MOBILITY;
                DrawMobility(_mobileDataTwo, "Two");
                if (_mobileDataTwo._abilityName == null || _mobileDataTwo._abilityName.Length < 1)
                {
                    EditorGUILayout.HelpBox("Each Ability needs a name before it can be created!", MessageType.Info);
                }
                else
                {
                    _twoBool = true;
                }
                break;


            case AbilityTypes.SELFBUFF:
                _selfDataTwo._abilityType = AbilityTypes.SELFBUFF;
                DrawSelfBuff(_selfDataTwo, "Two");
                if (_selfDataTwo._abilityName == null || _selfDataTwo._abilityName.Length < 1)
                {
                    EditorGUILayout.HelpBox("Each Ability needs a name before it can be created!", MessageType.Info);
                }
                else
                {
                    _twoBool = true;
                }
                break;


            case AbilityTypes.PROJECTILE:
                _projDataTwo._abilityType = AbilityTypes.PROJECTILE;
                DrawProjectile(_projDataTwo, "Two");
                if (_projDataTwo._abilityName == null || _projDataTwo._abilityName.Length < 1)
                {
                    EditorGUILayout.HelpBox("Each Ability needs a name before it can be created!", MessageType.Info);
                }
                else
                {
                    _twoBool = true;
                }
                break;
        }
        GUILayout.EndArea();

        GUILayout.BeginArea(_abilityThreeRect);
        switch (_abilityThreeSetting)
        {
            case AbilityTypes.AOE:
                _AOEDataThree._abilityType = AbilityTypes.AOE;
                DrawAOE(_AOEDataThree, "Three");
                if (_AOEDataThree._abilityName == null || _AOEDataThree._abilityName.Length < 1)
                {
                    EditorGUILayout.HelpBox("Each Ability needs a name before it can be created!", MessageType.Info);
                }
                else
                {
                    _threeBool = true;
                }
                break;


            case AbilityTypes.MOBILITY:
                _mobileDataThree._abilityType = AbilityTypes.MOBILITY;
                DrawMobility(_mobileDataThree, "Three");
                if (_mobileDataThree._abilityName == null || _mobileDataThree._abilityName.Length < 1)
                {
                    EditorGUILayout.HelpBox("Each Ability needs a name before it can be created!", MessageType.Info);
                }
                else
                {
                    _threeBool = true;
                }
                break;


            case AbilityTypes.SELFBUFF:
                _selfDataThree._abilityType = AbilityTypes.SELFBUFF;
                DrawSelfBuff(_selfDataThree, "Three");
                if (_selfDataThree._abilityName == null || _selfDataThree._abilityName.Length < 1)
                {
                    EditorGUILayout.HelpBox("Each Ability needs a name before it can be created!", MessageType.Info);
                }
                else
                {
                    _threeBool = true;
                }
                break;


            case AbilityTypes.PROJECTILE:
                _projDataThree._abilityType = AbilityTypes.PROJECTILE;
                DrawProjectile(_projDataThree, "Three");
                if (_projDataThree._abilityName == null || _projDataThree._abilityName.Length < 1)
                {
                    EditorGUILayout.HelpBox("Each Ability needs a name before it can be created!", MessageType.Info);
                }
                else
                {
                    _threeBool = true;
                }

                break;
        }
        GUILayout.EndArea();

        GUILayout.BeginArea(_abilityFourRect);
        switch (_abilityFourSetting)
        {


            case AbilityTypes.AOE:
                _AOEDataFour._abilityType = AbilityTypes.AOE;
                DrawAOE(_AOEDataFour, "Four");
                if (_AOEDataFour._abilityName == null || _AOEDataFour._abilityName.Length < 1)
                {
                    EditorGUILayout.HelpBox("Each Ability needs a name before it can be created!", MessageType.Info);
                }
                else
                {
                    _fourBool = true;
                }
                break;


            case AbilityTypes.MOBILITY:
                _mobileDataFour._abilityType = AbilityTypes.MOBILITY;
                DrawMobility(_mobileDataFour, "Four");
                if (_mobileDataFour._abilityName == null || _mobileDataFour._abilityName.Length < 1)
                {
                    EditorGUILayout.HelpBox("Each Ability needs a name before it can be created!", MessageType.Info);
                }
                else
                {
                    _fourBool = true;
                }
                break;


            case AbilityTypes.SELFBUFF:
                _selfDataFour._abilityType = AbilityTypes.SELFBUFF;
                DrawSelfBuff(_selfDataFour, "Four");
                if (_selfDataFour._abilityName == null || _selfDataFour._abilityName.Length < 1)
                {
                    EditorGUILayout.HelpBox("Each Ability needs a name before it can be created!", MessageType.Info);
                }
                else
                {
                    _fourBool = true;
                }
                break;


            case AbilityTypes.PROJECTILE:
                _projDataFour._abilityType = AbilityTypes.PROJECTILE;
                DrawProjectile(_projDataFour, "Four");
                if (_projDataFour._abilityName == null || _projDataFour._abilityName.Length < 1)
                {
                    EditorGUILayout.HelpBox("Each Ability needs a name before it can be created!", MessageType.Info);
                }
                else
                {
                    _fourBool = true;
                }
                break;
        }
        GUILayout.EndArea();
    }

    void DrawAOE(AOEAbilityData _aoeData, string _number)
    {
        GUILayout.BeginVertical();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Ability "  + _number + " (AOE)");
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Ability Name");
        _aoeData._abilityName = GUILayout.TextField(_aoeData._abilityName);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Description");
        _aoeData._description = GUILayout.TextField(_aoeData._description);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Cooldown");
        _aoeData._cooldown = EditorGUILayout.FloatField(_aoeData._cooldown);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Radius");
        _aoeData._radius = EditorGUILayout.FloatField(_aoeData._radius);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Damage or heal amount");
        _aoeData._effectAmount = EditorGUILayout.FloatField(_aoeData._effectAmount);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Spell Key");
        _aoeData._keyToUse = (KeyCode)EditorGUILayout.EnumPopup(_aoeData._keyToUse);
        GUILayout.EndHorizontal();


        if (_number.Equals("Four") && _oneBool && _twoBool && _threeBool && _fourBool)
        {
            if (GUILayout.Button("Create and Save Character!", GUILayout.Height(30)))
            {
                CreateAssets();
                window.Close();
            }
        }

        GUILayout.EndVertical();
    }

    void DrawSelfBuff(SelfAbilityData _selfBuffData, string _number)
    {
        GUILayout.BeginVertical();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Ability " + _number + " (Selfbuff)");
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Ability Name");
        _selfBuffData._abilityName = GUILayout.TextField(_selfBuffData._abilityName);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Description");
        _selfBuffData._description = GUILayout.TextField(_selfBuffData._description);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Cooldown");
        _selfBuffData._cooldown = EditorGUILayout.FloatField(_selfBuffData._cooldown);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Duration");
        _selfBuffData._duration = EditorGUILayout.FloatField(_selfBuffData._duration);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Spell Key");
        _selfBuffData._keyToUse = (KeyCode)EditorGUILayout.EnumPopup(_selfBuffData._keyToUse);
        GUILayout.EndHorizontal();

        if (_number.Equals("Four") && _oneBool && _twoBool && _threeBool && _fourBool)
        {
            if (GUILayout.Button("Create and Save Character!", GUILayout.Height(30)))
            {
                CreateAssets();
                window.Close();
            }
        }

        GUILayout.EndVertical();
    }    
    void DrawProjectile(ProjectileAbilityData _projectileData, string _number)
    {
        GUILayout.BeginVertical();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Ability " + _number + " (Projectile)");
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Ability Name");
        _projectileData._abilityName = GUILayout.TextField(_projectileData._abilityName);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Description");
        _projectileData._description = GUILayout.TextField(_projectileData._description);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Cooldown");
        _projectileData._cooldown = EditorGUILayout.FloatField(_projectileData._cooldown);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Range");
        _projectileData._range = EditorGUILayout.FloatField(_projectileData._range);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Damage or heal amount");
        _projectileData._effectAmount = EditorGUILayout.FloatField(_projectileData._effectAmount);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Spell Key");
        _projectileData._keyToUse = (KeyCode)EditorGUILayout.EnumPopup(_projectileData._keyToUse);
        GUILayout.EndHorizontal();

        if (_number.Equals("Four") && _oneBool && _twoBool && _threeBool && _fourBool)
        {
            if (GUILayout.Button("Create and Save Character!", GUILayout.Height(30)))
            {
                CreateAssets();
                window.Close();
            }
        }

        GUILayout.EndVertical();
    }

     void DrawMobility(MobilityData _mobilityData, string _number)
    {
        GUILayout.BeginVertical();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Ability " + _number + " (Mobility)");
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Ability Name");
        _mobilityData._abilityName = GUILayout.TextField(_mobilityData._abilityName);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Description");
        _mobilityData._description = GUILayout.TextField(_mobilityData._description);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Cooldown");
        _mobilityData._cooldown = EditorGUILayout.FloatField(_mobilityData._cooldown);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Max Distance");
        _mobilityData._maxDistance = EditorGUILayout.FloatField(_mobilityData._maxDistance);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Speed");
        _mobilityData._speed = EditorGUILayout.FloatField(_mobilityData._speed);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Spell Key");
        _mobilityData._keyToUse = (KeyCode)EditorGUILayout.EnumPopup(_mobilityData._keyToUse);
        GUILayout.EndHorizontal();


        if (_number.Equals("Four") && _oneBool && _twoBool && _threeBool && _fourBool)
        {
            if (GUILayout.Button("Create and Save Character!", GUILayout.Height(30)))
            {
                CreateAssets();
                window.Close();
            }
        }

        GUILayout.EndVertical();
    }

    void CreateAssets()
    {
        string prefabToUsePath = "Assets/CharacterCreator/prefabs/DoNotMove/Character.prefab";

        string characterPath = "Assets/CharacterCreator/prefabs/CharacterData/";

        string newPath = "Assets/CharacterCreator/prefabs/Characters/";

        string dataPath = "Assets/CharacterCreator/resources/";
        string dataPathTwo = "Assets/CharacterCreator/resources/";
        string dataPathThree = "Assets/CharacterCreator/resources/";
        string dataPathFour = "Assets/CharacterCreator/resources/";

        switch (_abilityOneSetting)
        {
            case AbilityTypes.PROJECTILE:
                ScriptWriter.Write(_projData._abilityName, AbilityTypes.PROJECTILE);
                dataPath += "Projectile/" + _projData._abilityName + ".asset";
                AssetDatabase.CreateAsset(_projData, dataPath);
                _characterToMake._abilityOne = _projData;
                break;

            case AbilityTypes.AOE:
                ScriptWriter.Write(_AOEData._abilityName, AbilityTypes.AOE);
                dataPath += "AOE/" + _AOEData._abilityName + ".asset";
                AssetDatabase.CreateAsset(_AOEData, dataPath);
                _characterToMake._abilityOne = _AOEData;
                break;

            case AbilityTypes.MOBILITY:
                ScriptWriter.Write(_mobileData._abilityName, AbilityTypes.MOBILITY);
                dataPath += "Mobility/" + _mobileData._abilityName + ".asset";
                AssetDatabase.CreateAsset(_mobileData, dataPath);
                _characterToMake._abilityOne = _mobileData;
                break;

            case AbilityTypes.SELFBUFF:
                ScriptWriter.Write(_selfData._abilityName, AbilityTypes.SELFBUFF);
                dataPath += "Selfbuff/" + _selfData._abilityName + ".asset";
                AssetDatabase.CreateAsset(_selfData, dataPath);
                _characterToMake._abilityOne = _selfData;
                break;
        }

        switch (_abilityTwoSetting)
        {
            case AbilityTypes.PROJECTILE:
                ScriptWriter.Write(_projDataTwo._abilityName, AbilityTypes.PROJECTILE);
                dataPathTwo += "Projectile/" + _projDataTwo._abilityName + ".asset";
                AssetDatabase.CreateAsset(_projDataTwo, dataPathTwo);
                _characterToMake._abilityTwo = _projDataTwo;

                break;

            case AbilityTypes.AOE:
                ScriptWriter.Write(_AOEDataTwo._abilityName, AbilityTypes.AOE);
                dataPathTwo += "AOE/" + _AOEDataTwo._abilityName + ".asset";
                AssetDatabase.CreateAsset(_AOEDataTwo, dataPathTwo);
                _characterToMake._abilityTwo = _AOEDataTwo;
                break;

            case AbilityTypes.MOBILITY:
                ScriptWriter.Write(_mobileDataTwo._abilityName, AbilityTypes.MOBILITY);
                dataPathTwo += "Mobility/" + _mobileDataTwo._abilityName + ".asset";
                AssetDatabase.CreateAsset(_mobileDataTwo, dataPathTwo);
                _characterToMake._abilityTwo = _mobileDataTwo;
                break;

            case AbilityTypes.SELFBUFF:
                ScriptWriter.Write(_selfDataTwo._abilityName, AbilityTypes.SELFBUFF);
                dataPathTwo += "Selfbuff/" + _selfDataTwo._abilityName + ".asset";
                AssetDatabase.CreateAsset(_selfDataTwo, dataPathTwo);
                _characterToMake._abilityTwo = _selfDataTwo;

                break;
        }

        switch (_abilityThreeSetting)
        {
            case AbilityTypes.PROJECTILE:
                ScriptWriter.Write(_projDataThree._abilityName, AbilityTypes.PROJECTILE);
                dataPathThree += "Projectile/" + _projDataThree._abilityName + ".asset";
                AssetDatabase.CreateAsset(_projDataThree, dataPathThree);
                _characterToMake._abilityThree = _projDataThree;
                break;

            case AbilityTypes.AOE:
                ScriptWriter.Write(_AOEDataThree._abilityName, AbilityTypes.AOE);
                dataPathThree += "AOE/" + _AOEDataThree._abilityName + ".asset";
                AssetDatabase.CreateAsset(_AOEDataThree, dataPathThree);
                _characterToMake._abilityThree = _AOEDataThree;
                break;

            case AbilityTypes.MOBILITY:
                ScriptWriter.Write(_mobileDataThree._abilityName, AbilityTypes.MOBILITY);
                dataPathThree += "Mobility/" + _mobileDataThree._abilityName + ".asset";
                AssetDatabase.CreateAsset(_mobileDataThree, dataPathThree);
                _characterToMake._abilityThree = _mobileDataThree;

                break;

            case AbilityTypes.SELFBUFF:
                ScriptWriter.Write(_selfDataThree._abilityName, AbilityTypes.SELFBUFF);
                dataPathThree += "Selfbuff/" + _selfDataThree._abilityName + ".asset";
                AssetDatabase.CreateAsset(_selfDataThree, dataPathThree);
                _characterToMake._abilityThree = _selfDataThree;

                break;
        }

        switch (_abilityFourSetting)
        {
            case AbilityTypes.PROJECTILE:
                ScriptWriter.Write(_projDataFour._abilityName, AbilityTypes.PROJECTILE);
                dataPathFour += "Projectile/" + _projDataFour._abilityName + ".asset";
                AssetDatabase.CreateAsset(_projDataFour, dataPathFour);
                _characterToMake._abilityFour = _projDataFour;
                break;

            case AbilityTypes.AOE:
                ScriptWriter.Write(_AOEDataFour._abilityName, AbilityTypes.AOE);
                dataPathFour += "AOE/" + _AOEDataFour._abilityName + ".asset";
                AssetDatabase.CreateAsset(_AOEDataFour, dataPathFour);
                _characterToMake._abilityFour = _AOEDataFour;

                break;

            case AbilityTypes.MOBILITY:
                ScriptWriter.Write(_mobileDataFour._abilityName, AbilityTypes.MOBILITY);
                dataPathFour += "Mobility/" + _mobileDataFour._abilityName + ".asset";
                AssetDatabase.CreateAsset(_mobileDataFour, dataPathFour);
                _characterToMake._abilityFour = _mobileDataFour;
                break;

            case AbilityTypes.SELFBUFF:
                ScriptWriter.Write(_selfDataFour._abilityName, AbilityTypes.SELFBUFF);
                dataPathFour += "Selfbuff/" + _selfDataFour._abilityName + ".asset";
                AssetDatabase.CreateAsset(_selfDataFour, dataPathFour);
                _characterToMake._abilityFour = _selfDataFour;
                break;
        }

        //create character now
        _characterToMake._name = CharacterCreatorTool.CharacterInfo._name;
        _characterToMake._race = CharacterCreatorTool.CharacterInfo._race;

        characterPath += _characterToMake._name + ".asset";

        AssetDatabase.CreateAsset(_characterToMake, characterPath);



        newPath += _characterToMake._name + ".prefab";


        AssetDatabase.CopyAsset(prefabToUsePath, newPath);

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

        GameObject charPrefab = (GameObject)AssetDatabase.LoadAssetAtPath(newPath, typeof(GameObject));
        if(charPrefab.GetComponent<DataHolder>() == null)
        {
            charPrefab.AddComponent(typeof(DataHolder));
        }
        charPrefab.GetComponent<DataHolder>()._characterInfo = _characterToMake;
    }
}

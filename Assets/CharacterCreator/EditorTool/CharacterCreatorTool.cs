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
        _charData.name = EditorGUILayout.TextField(_charData.name);
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

        if(GUILayout.Button("Create Abilities", GUILayout.Height(40)))
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

    Rect _abilityOneRect;
    Rect _abilityTwoRect;
    Rect _abilityThreeRect;
    Rect _abilityFourRect;

    static AbilitySettings window;

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
                GUILayout.BeginVertical();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Ability One (AOE)");
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Ability Name");
                _AOEData._abilityName = GUILayout.TextField(_AOEData._abilityName);
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Description");
                _AOEData._description = GUILayout.TextField(_AOEData._description);
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Cooldown");
                _AOEData._cooldown = EditorGUILayout.FloatField(_AOEData._cooldown);
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Radius");
                _AOEData._radius = EditorGUILayout.FloatField(_AOEData._radius);
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Damage or heal amount");
                _AOEData._effectAmount = EditorGUILayout.FloatField(_AOEData._effectAmount);
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Damage or heal amount");
                _AOEData._effectAmount = EditorGUILayout.FloatField(_AOEData._effectAmount);
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Spell Key");
                _AOEData._keyToUse = (KeyCode)EditorGUILayout.EnumPopup(_AOEData._keyToUse);
                GUILayout.EndHorizontal();

                GUILayout.EndVertical();
                break;


            case AbilityTypes.MOBILITY:
                _mobileData._abilityType = AbilityTypes.MOBILITY;

                GUILayout.BeginVertical();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Ability One (Mobility)");
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Ability Name");
                _mobileData._abilityName = GUILayout.TextField(_mobileData._abilityName);
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Description");
                _mobileData._description = GUILayout.TextField(_mobileData._description);
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Cooldown");
                _mobileData._cooldown = EditorGUILayout.FloatField(_mobileData._cooldown);
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Max Distance");
                _mobileData._maxDistance = EditorGUILayout.FloatField(_mobileData._maxDistance);
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Speed");
                _mobileData._speed = EditorGUILayout.FloatField(_mobileData._speed);
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Spell Key");
                _mobileData._keyToUse = (KeyCode)EditorGUILayout.EnumPopup(_mobileData._keyToUse);
                GUILayout.EndHorizontal();

                GUILayout.EndVertical();
                break;


            case AbilityTypes.SELFBUFF:
                _selfData._abilityType = AbilityTypes.SELFBUFF;

                GUILayout.BeginVertical();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Ability One (Selfbuff)");
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Ability Name");
                _selfData._abilityName = GUILayout.TextField(_selfData._abilityName);
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Description");
                _selfData._description = GUILayout.TextField(_selfData._description);
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Cooldown");
                _selfData._cooldown = EditorGUILayout.FloatField(_selfData._cooldown);
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Duration");
                _selfData._duration = EditorGUILayout.FloatField(_selfData._duration);
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Spell Key");
                _selfData._keyToUse = (KeyCode)EditorGUILayout.EnumPopup(_selfData._keyToUse);
                GUILayout.EndHorizontal();

                GUILayout.EndVertical();
                break;


            case AbilityTypes.PROJECTILE:
                _projData._abilityType = AbilityTypes.PROJECTILE;
                GUILayout.BeginVertical();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Ability One (Projectile)");
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Ability Name");
                _projData._abilityName = GUILayout.TextField(_projData._abilityName);
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Description");
                _projData._description = GUILayout.TextField(_projData._description);
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Cooldown");
                _projData._cooldown = EditorGUILayout.FloatField(_projData._cooldown);
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Range");
                _projData._range = EditorGUILayout.FloatField(_projData._range);
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Damage or heal amount");
                _projData._effectAmount = EditorGUILayout.FloatField(_projData._effectAmount);
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Spell Key");
                _projData._keyToUse = (KeyCode)EditorGUILayout.EnumPopup(_projData._keyToUse);
                GUILayout.EndHorizontal();

                GUILayout.EndVertical();
                break;
        }
        GUILayout.EndArea();

        GUILayout.BeginArea(_abilityTwoRect);
        switch (_abilityTwoSetting)
        {


            case AbilityTypes.AOE:
                _AOEDataTwo._abilityType = AbilityTypes.AOE;
                GUILayout.BeginVertical();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Ability Two (AOE)");
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Ability Name");
                _AOEDataTwo._abilityName = GUILayout.TextField(_AOEDataTwo._abilityName);
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Description");
                _AOEDataTwo._description = GUILayout.TextField(_AOEDataTwo._description);
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Cooldown");
                _AOEDataTwo._cooldown = EditorGUILayout.FloatField(_AOEDataTwo._cooldown);
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Radius");
                _AOEDataTwo._radius = EditorGUILayout.FloatField(_AOEDataTwo._radius);
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Damage or heal amount");
                _AOEDataTwo._effectAmount = EditorGUILayout.FloatField(_AOEDataTwo._effectAmount);
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Spell Key");
                _AOEDataTwo._keyToUse = (KeyCode)EditorGUILayout.EnumPopup(_AOEDataTwo._keyToUse);
                GUILayout.EndHorizontal();

                GUILayout.EndVertical();
                break;


            case AbilityTypes.MOBILITY:
                _mobileDataTwo._abilityType = AbilityTypes.MOBILITY;
                GUILayout.BeginVertical();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Ability Two (Mobility)");
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Ability Name");
                _mobileDataTwo._abilityName = GUILayout.TextField(_mobileDataTwo._abilityName);
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Description");
                _mobileDataTwo._description = GUILayout.TextField(_mobileDataTwo._description);
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Cooldown");
                _mobileDataTwo._cooldown = EditorGUILayout.FloatField(_mobileDataTwo._cooldown);
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Max Distance");
                _mobileDataTwo._maxDistance = EditorGUILayout.FloatField(_mobileDataTwo._maxDistance);
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Speed");
                _mobileDataTwo._speed = EditorGUILayout.FloatField(_mobileDataTwo._speed);
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Spell Key");
                _mobileDataTwo._keyToUse = (KeyCode)EditorGUILayout.EnumPopup(_mobileDataTwo._keyToUse);
                GUILayout.EndHorizontal();

                GUILayout.EndVertical();
                break;


            case AbilityTypes.SELFBUFF:
                _selfDataTwo._abilityType = AbilityTypes.SELFBUFF;

                GUILayout.BeginVertical();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Ability Two (Selfbuff)");
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Ability Name");
                _selfDataTwo._abilityName = GUILayout.TextField(_selfDataTwo._abilityName);
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Description");
                _selfDataTwo._description = GUILayout.TextField(_selfDataTwo._description);
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Cooldown");
                _selfDataTwo._cooldown = EditorGUILayout.FloatField(_selfDataTwo._cooldown);
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Duration");
                _selfDataTwo._duration = EditorGUILayout.FloatField(_selfDataTwo._duration);
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Spell Key");
                _selfDataTwo._keyToUse = (KeyCode)EditorGUILayout.EnumPopup(_selfDataTwo._keyToUse);
                GUILayout.EndHorizontal();

                GUILayout.EndVertical();
                break;


            case AbilityTypes.PROJECTILE:
                _projDataTwo._abilityType = AbilityTypes.PROJECTILE;
                GUILayout.BeginVertical();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Ability Two (Projectile)");
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Ability Name");
                _projDataTwo._abilityName = GUILayout.TextField(_projDataTwo._abilityName);
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Description");
                _projDataTwo._description = GUILayout.TextField(_projDataTwo._description);
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Cooldown");
                _projDataTwo._cooldown = EditorGUILayout.FloatField(_projDataTwo._cooldown);
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Range");
                _projDataTwo._range = EditorGUILayout.FloatField(_projDataTwo._range);
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Damage or heal amount");
                _projDataTwo._effectAmount = EditorGUILayout.FloatField(_projDataTwo._effectAmount);
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Spell Key");
                _projDataTwo._keyToUse = (KeyCode)EditorGUILayout.EnumPopup(_projDataTwo._keyToUse);
                GUILayout.EndHorizontal();

                GUILayout.EndVertical();
                break;
        }
        GUILayout.EndArea();

        GUILayout.BeginArea(_abilityThreeRect);
        switch (_abilityThreeSetting)
        {
            case AbilityTypes.AOE:
                _AOEDataThree._abilityType = AbilityTypes.AOE;
                GUILayout.BeginVertical();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Ability Three (AOE)");
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Ability Name");
                _AOEDataThree._abilityName = GUILayout.TextField(_AOEDataThree._abilityName);
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Description");
                _AOEDataThree._description = GUILayout.TextField(_AOEDataThree._description);
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Cooldown");
                _AOEDataThree._cooldown = EditorGUILayout.FloatField(_AOEDataThree._cooldown);
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Radius");
                _AOEDataThree._radius = EditorGUILayout.FloatField(_AOEDataThree._radius);
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Damage or heal amount");
                _AOEDataThree._effectAmount = EditorGUILayout.FloatField(_AOEDataThree._effectAmount);
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Spell Key");
                _AOEDataThree._keyToUse = (KeyCode)EditorGUILayout.EnumPopup(_AOEDataThree._keyToUse);
                GUILayout.EndHorizontal();

                GUILayout.EndVertical();
                break;


            case AbilityTypes.MOBILITY:
                _mobileDataThree._abilityType = AbilityTypes.MOBILITY;
                GUILayout.BeginVertical();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Ability Three (Mobility)");
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Ability Name");
                _mobileDataThree._abilityName = GUILayout.TextField(_mobileDataThree._abilityName);
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Description");
                _mobileDataThree._description = GUILayout.TextField(_mobileDataThree._description);
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Cooldown");
                _mobileDataThree._cooldown = EditorGUILayout.FloatField(_mobileDataThree._cooldown);
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Max Distance");
                _mobileDataThree._maxDistance = EditorGUILayout.FloatField(_mobileDataThree._maxDistance);
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Speed");
                _mobileDataThree._speed = EditorGUILayout.FloatField(_mobileDataThree._speed);
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Spell Key");
                _mobileDataThree._keyToUse = (KeyCode)EditorGUILayout.EnumPopup(_mobileDataThree._keyToUse);
                GUILayout.EndHorizontal();

                GUILayout.EndVertical();
                break;


            case AbilityTypes.SELFBUFF:
                _selfDataThree._abilityType = AbilityTypes.SELFBUFF;

                GUILayout.BeginVertical();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Ability Three (Selfbuff)");
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Ability Name");
                _selfDataThree._abilityName = GUILayout.TextField(_selfDataThree._abilityName);
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Description");
                _selfDataThree._description = GUILayout.TextField(_selfDataThree._description);
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Cooldown");
                _selfDataThree._cooldown = EditorGUILayout.FloatField(_selfDataThree._cooldown);
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Duration");
                _selfDataThree._duration = EditorGUILayout.FloatField(_selfDataThree._duration);
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Spell Key");
                _selfDataThree._keyToUse = (KeyCode)EditorGUILayout.EnumPopup(_selfDataThree._keyToUse);
                GUILayout.EndHorizontal();

                GUILayout.EndVertical();
                break;


            case AbilityTypes.PROJECTILE:
                _projDataThree._abilityType = AbilityTypes.PROJECTILE;
                GUILayout.BeginVertical();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Ability Three (Projectile)");
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Ability Name");
                _projDataThree._abilityName = GUILayout.TextField(_projDataThree._abilityName);
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Description");
                _projDataThree._description = GUILayout.TextField(_projDataThree._description);
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Cooldown");
                _projDataThree._cooldown = EditorGUILayout.FloatField(_projDataThree._cooldown);
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Range");
                _projDataThree._range = EditorGUILayout.FloatField(_projDataThree._range);
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Damage or heal amount");
                _projDataThree._effectAmount = EditorGUILayout.FloatField(_projDataThree._effectAmount);
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Spell Key");
                _projDataThree._keyToUse = (KeyCode)EditorGUILayout.EnumPopup(_projDataThree._keyToUse);
                GUILayout.EndHorizontal();

                GUILayout.EndVertical();
                break;
        }
        GUILayout.EndArea();

        GUILayout.BeginArea(_abilityFourRect);
        switch (_abilityFourSetting)
        {


            case AbilityTypes.AOE:
                _AOEDataFour._abilityType = AbilityTypes.AOE;
                GUILayout.BeginVertical();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Ability Four (AOE)");
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Ability Name");
                _AOEDataFour._abilityName = GUILayout.TextField(_AOEDataFour._abilityName);
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Description");
                _AOEDataFour._description = GUILayout.TextField(_AOEDataFour._description);
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Cooldown");
                _AOEDataFour._cooldown = EditorGUILayout.FloatField(_AOEDataFour._cooldown);
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Radius");
                _AOEDataFour._radius = EditorGUILayout.FloatField(_AOEDataFour._radius);
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Damage or heal amount");
                _AOEDataFour._effectAmount = EditorGUILayout.FloatField(_AOEDataFour._effectAmount);
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Spell Key");
                _AOEDataFour._keyToUse = (KeyCode)EditorGUILayout.EnumPopup(_AOEDataFour._keyToUse);
                GUILayout.EndHorizontal();

                if (GUILayout.Button("Create and Save Character!", GUILayout.Height(30)))
                {
                    CreateAssets();
                }

                GUILayout.EndVertical();
                break;


            case AbilityTypes.MOBILITY:
                _mobileDataFour._abilityType = AbilityTypes.MOBILITY;
                GUILayout.BeginVertical();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Ability Four (Mobility)");
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Ability Name");
                _mobileDataFour._abilityName = GUILayout.TextField(_mobileDataFour._abilityName);
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Description");
                _mobileDataFour._description = GUILayout.TextField(_mobileDataFour._description);
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Cooldown");
                _mobileDataFour._cooldown = EditorGUILayout.FloatField(_mobileDataFour._cooldown);
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Max Distance");
                _mobileDataFour._maxDistance = EditorGUILayout.FloatField(_mobileDataFour._maxDistance);
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Speed");
                _mobileDataFour._speed = EditorGUILayout.FloatField(_mobileDataFour._speed);
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Spell Key");
                _mobileDataFour._keyToUse = (KeyCode)EditorGUILayout.EnumPopup(_mobileDataFour._keyToUse);
                GUILayout.EndHorizontal();

                if (GUILayout.Button("Create and Save Character!", GUILayout.Height(30)))
                {
                    CreateAssets();
                }

                GUILayout.EndVertical();
                break;


            case AbilityTypes.SELFBUFF:
                _selfDataFour._abilityType = AbilityTypes.SELFBUFF;

                GUILayout.BeginVertical();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Ability Four (Selfbuff)");
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Ability Name");
                _selfDataFour._abilityName = GUILayout.TextField(_selfDataFour._abilityName);
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Description");
                _selfDataFour._description = GUILayout.TextField(_selfDataFour._description);
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Cooldown");
                _selfDataFour._cooldown = EditorGUILayout.FloatField(_selfDataFour._cooldown);
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Duration");
                _selfDataFour._duration = EditorGUILayout.FloatField(_selfDataFour._duration);
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Spell Key");
                _selfDataFour._keyToUse = (KeyCode)EditorGUILayout.EnumPopup(_selfDataFour._keyToUse);
                GUILayout.EndHorizontal();

                if (GUILayout.Button("Create and Save Character!", GUILayout.Height(30)))
                {
                    CreateAssets();
                }

                GUILayout.EndVertical();
                break;


            case AbilityTypes.PROJECTILE:
                _projDataFour._abilityType = AbilityTypes.PROJECTILE;
                GUILayout.BeginVertical();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Ability Four (Projectile)");
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Ability Name");
                _projDataFour._abilityName = GUILayout.TextField(_projDataFour._abilityName);
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Description");
                _projDataFour._description = GUILayout.TextField(_projDataFour._description);
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Cooldown");
                _projDataFour._cooldown = EditorGUILayout.FloatField(_projDataFour._cooldown);
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Range");
                _projDataFour._range = EditorGUILayout.FloatField(_projDataFour._range);
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Damage or heal amount");
                _projDataFour._effectAmount = EditorGUILayout.FloatField(_projDataFour._effectAmount);
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Spell Key");
                _projDataFour._keyToUse = (KeyCode)EditorGUILayout.EnumPopup(_projDataFour._keyToUse);
                GUILayout.EndHorizontal();

                if(GUILayout.Button("Create and Save Character!", GUILayout.Height(30)))
                {
                    CreateAssets();
                }

                GUILayout.EndVertical();
                break;
        }
        GUILayout.EndArea();
    }

    void CreateAssets()
    {

    }
}

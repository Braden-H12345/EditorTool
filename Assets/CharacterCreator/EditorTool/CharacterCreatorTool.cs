using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CharacterCreatorTool : EditorWindow
{
    Texture2D _headerTexture;
    Texture2D _bodyTexture;

    Color _headerColor = new Color(0.6033731f, 0.8584906f, 0.8327252f, 1f);
    Color _bodyColor = new Color(0.6509434f, 0.5434763f, 0.6356393f, 1f);
    Rect _headerRect;
    Rect _bodyRect;


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

    }
}

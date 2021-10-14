using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CharacterCreatorTool : EditorWindow
{
    [MenuItem("Window/Character Creator")]
    static void OpenWindow()
    {
        CharacterCreatorTool window = (CharacterCreatorTool)GetWindow(typeof(CharacterCreatorTool));
        window.minSize = new Vector2(600, 600);
        window.Show();
    }
}

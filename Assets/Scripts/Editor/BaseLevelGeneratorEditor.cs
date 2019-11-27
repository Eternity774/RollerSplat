using UnityEditor;
using UnityEngine;
using System.Collections;

[CustomEditor(typeof(BaseLevelGenerator))]
public class BaseLevelGeneratorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        BaseLevelGenerator myTarget = (BaseLevelGenerator)target;

        DrawDefaultInspector();
        EditorGUILayout.Space();

        if (myTarget.xLenght != myTarget.levelArray.GetLength(0) || myTarget.zLenght != myTarget.levelArray.GetLength(1))
        {
            myTarget.levelArray = new bool[myTarget.xLenght, myTarget.zLenght];
        }
        ChangeArrayWidthAndHeight(myTarget);
        EditorGUILayout.Space();

        if (GUILayout.Button("Generate base level"))
        {
            myTarget.GenerateBaseLevel();
        }

    }

    void ChangeArrayWidthAndHeight(BaseLevelGenerator target)
    {
        for (int j = 0; j < target.zLenght; j++)
        {
            EditorGUILayout.BeginHorizontal();
            for (int i = 0; i < target.xLenght; i++)
            {
                target.levelArray[i, j] = EditorGUILayout.Toggle(target.levelArray[i, j],GUILayout.Width(10));
            }
            EditorGUILayout.EndHorizontal();
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ToggleEventManager))]
public class ToggleEventManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        ToggleEventManager toggleEventManager = (ToggleEventManager)target;

        EditorGUILayout.PropertyField(serializedObject.FindProperty("ToggleMenu"));

        switch (toggleEventManager.ToggleMenu)
        {
            case ToggleEventManager.ToggleEventType.Status:
                EditorGUILayout.PropertyField(serializedObject.FindProperty("ToggleStatus"));
                break;
            case ToggleEventManager.ToggleEventType.Message:
                EditorGUILayout.PropertyField(serializedObject.FindProperty("ToggleMessage"));
                break;
            default:
                break;
        }

        serializedObject.ApplyModifiedProperties();
    }
}

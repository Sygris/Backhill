using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TriggerEventManager))]
public class TriggerEventManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        TriggerEventManager triggerEventManager = (TriggerEventManager)target;

        EditorGUILayout.PropertyField(serializedObject.FindProperty("TriggerMenu"));

        switch (triggerEventManager.TriggerMenu)
        {
            case TriggerEventManager.TriggerEventType.Status:
                EditorGUILayout.PropertyField(serializedObject.FindProperty("TriggerStatus"));
                break;
            case TriggerEventManager.TriggerEventType.Message:
                EditorGUILayout.PropertyField(serializedObject.FindProperty("TriggerMessage"));
                break;
            case TriggerEventManager.TriggerEventType.Animation:
                EditorGUILayout.PropertyField(serializedObject.FindProperty("TriggerAnimation"));
                break;
            case TriggerEventManager.TriggerEventType.Scene:
                EditorGUILayout.PropertyField(serializedObject.FindProperty("TriggerNewScene"));
                break;
            case TriggerEventManager.TriggerEventType.PlaySFX:
                EditorGUILayout.PropertyField(serializedObject.FindProperty("TriggerPlaySFX"));
                break;
            case TriggerEventManager.TriggerEventType.StopSFX:
                EditorGUILayout.PropertyField(serializedObject.FindProperty("TriggerStopSFX"));
                break;
            default:
                break;
        }

        if (GUILayout.Button("Add Another Event"))
            triggerEventManager.AddAnotherTriggerEvent();

        serializedObject.ApplyModifiedProperties();
    }
}

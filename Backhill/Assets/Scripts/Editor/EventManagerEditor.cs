using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(EventManager))]
public class EventManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EventManager eventManager = (EventManager)target;

        EditorGUILayout.PropertyField(serializedObject.FindProperty("ColliderType"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("_eventName"));

        if (GUILayout.Button("Generate"))
            eventManager.MakeEventCollider();

        serializedObject.ApplyModifiedProperties();
    }
}

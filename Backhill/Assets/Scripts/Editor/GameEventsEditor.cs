using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(EventManager))]
public class GameEventsEditor : Editor
{
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EventManager eventManager = (EventManager)target;

        EditorGUILayout.PropertyField(serializedObject.FindProperty("_name"));

        EditorGUILayout.PropertyField(serializedObject.FindProperty("_location"));

        if (GUILayout.Button("Generate Trigger Collider"))
            eventManager.MakeTriggerCollider();

        serializedObject.ApplyModifiedProperties();
    }
}

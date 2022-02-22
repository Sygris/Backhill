using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(EventManager))]
public class GameEventsEditor : Editor
{
    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EventManager eventManager = (EventManager)target;

        EditorGUILayout.PropertyField(serializedObject.FindProperty("ColliderType"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("_eventName"));


        //switch (eventManager.ColliderMenu)
        //{
        //    case EventManager.ColliderType.Trigger:
        //        EditorGUILayout.PropertyField(serializedObject.FindProperty("TriggerMenu"));

        //        switch (eventManager.TriggerMenu)
        //        {
        //            case EventManager.TriggerEventType.Status:
        //                EditorGUILayout.PropertyField(serializedObject.FindProperty("TriggerStatus"));
        //                break;
        //            case EventManager.TriggerEventType.Message:
        //                EditorGUILayout.PropertyField(serializedObject.FindProperty("TriggerMessage"));
        //                break;
        //            case EventManager.TriggerEventType.Animation:
        //                EditorGUILayout.PropertyField(serializedObject.FindProperty("TriggerAnimation"));
        //                break;
        //            default:
        //                break;
        //        }
        //        break;
        //    case EventManager.ColliderType.Toggle:
        //        EditorGUILayout.PropertyField(serializedObject.FindProperty("ToggleMenu"));

        //        switch (eventManager.ToggleMenu)
        //        {
        //            case EventManager.ToggleEventType.Status:
        //                EditorGUILayout.PropertyField(serializedObject.FindProperty("ToggleStatus"));
        //                break;
        //            case EventManager.ToggleEventType.Message:
        //                EditorGUILayout.PropertyField(serializedObject.FindProperty("ToggleMessage"));
        //                break;
        //            default:
        //                break;
        //        }
        //        break;
        //    default:
        //        break;
        //}

        if (GUILayout.Button("Generate"))
        {
            eventManager.MakeEventCollider();
        }

        serializedObject.ApplyModifiedProperties();
    }
}

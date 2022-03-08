using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(AIFOV))]
public class AIFOVEditor : Editor
{
    private void OnSceneGUI()
    {
        AIFOV detection = (AIFOV)target;
        Handles.color = Color.green;
        Handles.DrawWireArc(detection.transform.position, Vector3.up, Vector3.forward, 360, detection.detectionRadius);
        Vector3 viewAngleA = detection.DirFromAngle(-detection.viewAngle / 2, false);
        Vector3 viewAngleB = detection.DirFromAngle(detection.viewAngle / 2, false);

        Handles.DrawLine(detection.transform.position, detection.transform.position + viewAngleA * detection.detectionRadius);
        Handles.DrawLine(detection.transform.position, detection.transform.position + viewAngleB * detection.detectionRadius);

        Handles.color = Color.yellow;

    }
}

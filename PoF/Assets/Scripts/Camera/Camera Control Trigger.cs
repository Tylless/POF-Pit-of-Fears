using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEditor;
using System.Net;


public class CameraControlTrigger : MonoBehaviour
{
    public CustomInspectorObjects customInspectorObjects;
    private Collider2D _coll;
    private void Start()
    {
        _coll = GetComponent<Collider2D>();
    }



    private void OnTriggerExit2D(Collider2D coll)
    {
        if(coll.CompareTag("Player"))
        {
            Vector2 exitDirection = (coll.transform.position - _coll.bounds.center).normalized;

            if(customInspectorObjects.swapCameras && customInspectorObjects.cameraOnLeft != null && customInspectorObjects.cameraOnRight != null)
            {
                CameraManager.instance.SwapCameras(customInspectorObjects.cameraOnLeft, customInspectorObjects.cameraOnRight, exitDirection);
            }
        }
    }
}

[System.Serializable]
public class CustomInspectorObjects
{
    public bool swapCameras = false;
    

    [HideInInspector] public CinemachineVirtualCamera cameraOnLeft;
    [HideInInspector] public CinemachineVirtualCamera cameraOnRight;
}

#if UNITY_EDITOR
[CustomEditor(typeof(CameraControlTrigger))]
public class MyScriptEditor : Editor
{
    CameraControlTrigger cameraControlTrigger;

    private void OnEnable() 
    {
        cameraControlTrigger = (CameraControlTrigger)target;
    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        if(cameraControlTrigger.customInspectorObjects.swapCameras)
        {
            cameraControlTrigger.customInspectorObjects.cameraOnLeft = EditorGUILayout.ObjectField("Camera on Left", cameraControlTrigger.customInspectorObjects.cameraOnLeft, 
            typeof(CinemachineVirtualCamera), true) as CinemachineVirtualCamera;
            cameraControlTrigger.customInspectorObjects.cameraOnRight = EditorGUILayout.ObjectField("Camera on Right", cameraControlTrigger.customInspectorObjects.cameraOnRight, 
            typeof(CinemachineVirtualCamera), true) as CinemachineVirtualCamera;
        }

        if(GUI.changed)
        {
            EditorUtility.SetDirty(cameraControlTrigger);
        }
    }
}
#endif

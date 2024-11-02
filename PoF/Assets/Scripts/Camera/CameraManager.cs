using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CameraManager : MonoBehaviour
{

    public static CameraManager instance;
    public CinemachineVirtualCamera[] _allVirtualCamera;

 

    public CinemachineVirtualCamera _currentCamera;
    private CinemachineFramingTransposer _framingTransposer;

    
    // Start is called before the first frame update
     private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }

        for(int i = 0; i < _allVirtualCamera.Length; i++)
        {
            if(_allVirtualCamera[i].enabled)
            {
                _currentCamera = _allVirtualCamera[i];
                _framingTransposer = _currentCamera.GetCinemachineComponent<CinemachineFramingTransposer>();
            }
        }

        
    }
       public void SwapCameras(CinemachineVirtualCamera cameraFromLeft, CinemachineVirtualCamera cameraFromRight, Vector2 triggerExitDireciton)
    {
        if(_currentCamera == cameraFromLeft && triggerExitDireciton.x > 0f)
        {
            cameraFromRight.enabled = true;
            cameraFromLeft.enabled = false;
            _currentCamera = cameraFromRight;
            _framingTransposer = _currentCamera.GetCinemachineComponent<CinemachineFramingTransposer>();
        }
        if(_currentCamera == cameraFromRight && triggerExitDireciton.x < 0f)
        {
            cameraFromRight.enabled = false;
            cameraFromLeft.enabled = true;
            _currentCamera = cameraFromLeft;
            _framingTransposer = _currentCamera.GetCinemachineComponent<CinemachineFramingTransposer>();
        }
        
    }
     
   
}

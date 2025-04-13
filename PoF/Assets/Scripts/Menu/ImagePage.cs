using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ImageScreen : MonoBehaviour
{

    public Toggle vsyncTog, FStog;
    private int selectedResolution;
    public TMP_Text resolutionLabel;
    public String resolução;
    public List<ResItem> resolutions = new List<ResItem>();
    // Start is called before the first frame update
    void Start()
    {
        FStog.isOn = Screen.fullScreen;

        if(QualitySettings.vSyncCount == 0)
        {
            vsyncTog.isOn = false;
        }else
        {
            vsyncTog.isOn = true;
        }

        bool foundRes = false;
        for(int i = 0; i < resolutions.Count; i++)
        {
            if(Screen.width == resolutions[i].Horizontal && Screen.height == resolutions[i].Vertical)
            {
                foundRes = true;

                selectedResolution = i;

                UpdateResLabel();
            }
        }

        if(!foundRes)
        {
            ResItem newRes = new ResItem();
            {
                newRes.Horizontal = Screen.width;
                newRes.Vertical = Screen.height;

                resolutions.Add(newRes);
                selectedResolution = resolutions.Count - 1;

                UpdateResLabel();
            }
        }
       
    }
    
    // Update is called once per frame
    void Update()
    {
          
    }
    public void ResLeft()
    {
        selectedResolution --;
        if(selectedResolution < 0)
        {
            selectedResolution = 0;
        }
        UpdateResLabel();
       
    }
    public void ResRight()
    {
        selectedResolution ++;
        if(selectedResolution > resolutions.Count - 1)
        {
            selectedResolution = resolutions.Count - 1;
        }
        UpdateResLabel();
        
    }
    public void UpdateResLabel()
    {
        resolutionLabel.text = resolutions[selectedResolution].Horizontal.ToString() + " x " + resolutions[selectedResolution].Vertical.ToString() + resolução;
        
    }

    public void ApllyGraphics()
    {
        Screen.fullScreen = FStog.isOn;

        if(vsyncTog.isOn)
        {
            QualitySettings.vSyncCount = 1;
        }else
        {
            QualitySettings.vSyncCount = 0;

        }
        
        
        Screen.SetResolution(resolutions[selectedResolution].Horizontal, resolutions[selectedResolution].Horizontal, FStog.isOn);
    }

    
    
}
[System.Serializable]
public class ResItem
{
    public int Horizontal, Vertical;
}


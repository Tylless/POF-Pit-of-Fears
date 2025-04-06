using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public static CursorManager instance;
    public bool PauseOn;
    public bool CSPauseOn;
    public bool isCursorOn;
    public bool ForceCursor;
    // Start is called before the first frame update
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(CSPauseOn || PauseOn || ForceCursor)
        {
            isCursorOn = true;
        }else
        {
            isCursorOn = false;
        }
        Cursor.visible = isCursorOn;
    }
}

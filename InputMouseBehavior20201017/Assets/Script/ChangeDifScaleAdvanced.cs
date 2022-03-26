using System.Collections;
using System.Collections.Generic;
using UnityEngine;
///<summary>
///
///</summary>

public class ChangeDifScaleAdvanced : MonoBehaviour
{
    public bool isDown;
    public bool isScale;
    private Camera camera;
    public float[] fovs;
   public int fovIndex;
    private void Update()
    {
        isDown = Input.GetMouseButtonDown(1);
        if (isDown )
        {
            ScaleStart();
        }
        ScaleChange();

    }
    private void Start()
    {
        
        camera = GetComponent<Camera>();
    }
    public void ScaleStart()
    {
        // isScale++;
        //  fovIndex = isScale % fovs.Length;
        fovIndex = fovIndex < fovs.Length - 1 ? fovIndex + 1 : 0;
        //camera.fieldOfView = Mathf.Lerp(camera.fieldOfView, fovs[fovIndex], 0.1f);
        //camera.fieldOfView = fovs[fovIndex];
        
    }

    private void ScaleChange()
    {
        camera.fieldOfView = Mathf.Lerp(camera.fieldOfView, fovs[fovIndex], 0.1f);
        if (Mathf.Abs(camera.fieldOfView - fovs[fovIndex]) < 0.1f)
        {
            camera.fieldOfView = fovs[fovIndex];
        }
    }
}

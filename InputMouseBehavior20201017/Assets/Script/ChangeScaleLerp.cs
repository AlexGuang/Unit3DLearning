using System.Collections;
using System.Collections.Generic;
using UnityEngine;
///<summary>
///
///</summary>

public class ChangeScaleLerp : MonoBehaviour
{
    public Camera camera;
    public bool isScaled;
    public bool isDown;
    private void Start()
    {
        camera = GetComponent<Camera>();
    }
    private void Update()
    {
        isDown = Input.GetMouseButtonDown(0);
        if (isDown)
        {
            isScaled = !isScaled;
        }
        CameraScale();
    }
    private void CameraScale()
    {
        if (isScaled == false)
        {

            ScaleDown();
        }
        else
            ScaleUp();
    }

    private void ScaleDown()
    {
        camera.fieldOfView = Mathf.Lerp(camera.fieldOfView, 60, 0.1f);
        if (Mathf.Abs(camera.fieldOfView-60 )<0.1f)
        {
            camera.fieldOfView = 60;
        }

    }

    private void ScaleUp()
    {
        camera.fieldOfView = Mathf.Lerp(camera.fieldOfView, 20, 0.1f);
        if (Mathf.Abs(camera.fieldOfView - 20) < 0.1f)
        {
            camera.fieldOfView = 20;
        }
    }

}

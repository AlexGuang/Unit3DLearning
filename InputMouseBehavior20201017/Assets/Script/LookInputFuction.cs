using System.Collections;
using System.Collections.Generic;
using UnityEngine;
///<summary>
///
///</summary>

public class LookInputFuction : MonoBehaviour
{
    public bool isScaled;
    public bool isDown;
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
            this.GetComponent<Camera>().fieldOfView = 60;
        }
        else
            this.GetComponent<Camera>().fieldOfView = 20;
    }
}

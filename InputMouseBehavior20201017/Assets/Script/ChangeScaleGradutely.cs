using System.Collections;
using System.Collections.Generic;
using UnityEngine;
///<summary>
///
///</summary>

public class ChangeScaleGradutely : MonoBehaviour
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
          
            ScaleDown();
        }
        else
            ScaleUp();
    }

    private void ScaleDown()
    {
        if (this.GetComponent<Camera>().fieldOfView <= 60)
        {
            this.GetComponent<Camera>().fieldOfView += 1;
        }
        
    }

    private void ScaleUp()
    {
        if (this.GetComponent<Camera>().fieldOfView >= 20)
        {
            this.GetComponent<Camera>().fieldOfView -= 1;
        }
        
    }
}
   


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
///<summary>
///
///</summary>

public class CameraControl : MonoBehaviour
{
    float mouseMoveX;
    float mouseMoveY;
    private void Update()
    {
         mouseMoveX = Input.GetAxis("Mouse X");
        mouseMoveY = Input.GetAxis("Mouse Y");
        if (mouseMoveX!=0|| mouseMoveY!=0)
        {
            CameraRotate();
        }
       
    }
    private void CameraRotate()
    {
        this.transform.Rotate(0,mouseMoveX * 100*Time.deltaTime,0,Space.World);
        this.transform.Rotate(-mouseMoveY * 100 * Time.deltaTime,0, 0 );
    }
}

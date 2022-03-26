using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;
///<summary>
///
///</summary>
public enum ScaleLevel
{
    Level1,
    Level2,
    Level3,
    Level4
}
public class ChangeDifScale : MonoBehaviour
{
    public bool isDown;
    public ScaleLevel isScale;
    private void Update()
    {
        isDown = Input.GetMouseButtonDown(0);
        ScaleStart();
    }
    public void ScaleStart()
    {
        if (isDown)
        {
            switch (isScale)
            {
                case ScaleLevel.Level1:
                    isScale = ScaleLevel.Level2;
                    ScaleAction();
                    break;
                case ScaleLevel.Level2:
                    isScale = ScaleLevel.Level3;
                    ScaleAction();
                    break;
                case ScaleLevel.Level3:
                    isScale = ScaleLevel.Level4;
                    ScaleAction();
                    break;
                case ScaleLevel.Level4:
                    isScale = ScaleLevel.Level1;
                    ScaleAction();
                    break;
                
            }
            
        }
                
    }
    private void ScaleAction()
    {
        switch (isScale)
        {
            case ScaleLevel.Level1:
                this.GetComponent<Camera>().fieldOfView = 60;
                break;
            case ScaleLevel.Level2:
                this.GetComponent<Camera>().fieldOfView = 40;
                break;
            case ScaleLevel.Level3:
                this.GetComponent<Camera>().fieldOfView = 20;
                break;
            case ScaleLevel.Level4:
                this.GetComponent<Camera>().fieldOfView = 10;
                break;
            default:
                this.GetComponent<Camera>().fieldOfView = 60;
                break;
        }
    }
}

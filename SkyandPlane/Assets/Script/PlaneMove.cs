using System.Collections;
using System.Collections.Generic;
using UnityEngine;
///<summary>
///
///</summary>

public class PlaneMove : MonoBehaviour
{
    float planeFlyHorizontal;
    float planeFlyVertical;

    private void Update()
    {
        planeFlyHorizontal = Input.GetAxis("Horizontal");
        planeFlyVertical = Input.GetAxis("Vertical");
        if (planeFlyHorizontal != 0|| planeFlyVertical!=0)
        {
            MoveHorizential();
            MoveVertical();
        }
     
    }
    private void MoveHorizential()
    {
        if (planeFlyHorizontal != 0)
        {
            this.transform.Translate(planeFlyHorizontal * 10* Time.deltaTime, 0, 0);
        }
        
    
    }
    private void MoveVertical()
    {
        if (planeFlyVertical != 0)
        {
            this.transform.Translate(0,0,planeFlyVertical * 10 * Time.deltaTime);
        }


    }
}

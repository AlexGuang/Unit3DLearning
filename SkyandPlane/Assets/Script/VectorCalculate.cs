using System.Collections;
using System.Collections.Generic;
using UnityEngine;
///<summary>
///
///</summary>

public class VectorCalculate : MonoBehaviour
{
    Vector3 point;
    private void Start()
    {
        point = this.transform.position;
        FindWorldSpace();
    }
    private void FindWorldSpace()
    {
        
        Vector3 wolrdPoint2 = transform.TransformPoint(Mathf.Sin(30 * Mathf.Deg2Rad) * 10, 0, Mathf.Cos(30 * Mathf.Deg2Rad)*10);
        Debug.DrawLine(this.transform.position, wolrdPoint2,Color.red);
    }
}

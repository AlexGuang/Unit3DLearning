using System.Collections;
using System.Collections.Generic;
using UnityEngine;
///<summary>
///
///</summary>

public class MoveTheCube : MonoBehaviour
{
    private RaycastHit hit;
    private Ray ray;
    public LayerMask layer;
    private bool flag = false;
    public Transform carryParent;//拾取物体的父级
    private Transform carryObj;//拾取到的物体
  //  private Vector3 handPosition = (0, 0, -2);
    private void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
       // handPosition = (0, 0, -2);
        if (!flag)
        {
            if (Physics.Raycast(ray, out hit, 3, layer.value) && Input.GetMouseButtonDown(0))
            {
                flag = true;
                carryObj = hit.transform;
                carryObj.parent = carryParent;
                carryObj.localPosition = Vector3.zero;
                carryObj.localEulerAngles = new Vector3(0,0,5);
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                flag = false;
                carryObj.parent = null;
                carryObj.eulerAngles = new Vector3(0, carryObj.eulerAngles.y, 0);
            }
        }
       
    }
}

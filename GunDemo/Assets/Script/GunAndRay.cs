using System.Collections;
using System.Collections.Generic;
using UnityEngine;
///<summary>
///
///</summary>

public class GunAndRay : MonoBehaviour
{
    public Transform originalRay;
    private RaycastHit hit;
    public LayerMask layer;
    public RectTransform UI;//准心
    private LineRenderer line;
    private LineRenderer render;
    public float scrollSpeed = 30.0F;
    private void Start()
    {
        line = this.GetComponent<LineRenderer>();
       // render = this.GetComponent<Renderer>();
    }
    private void Update()
    {
        //练习：从枪口位置形成射线，准心效果
        if (Physics.Raycast(originalRay.position,-transform.forward, out hit,100,layer.value))
        {
            //准心显示
            Vector3 gunUI = Camera.main.WorldToScreenPoint(hit.point);
            UI.gameObject.SetActive(true);
            UI.position = gunUI; 
           // Debug.DrawLine(originalRay.position, hit.point, Color.red);
            //线渲染显示   
            line.enabled = true;
            line.SetPosition(0, originalRay.position);
            line.SetPosition(1, hit.point);
            float offset = Time.time * scrollSpeed;
            line.material.mainTextureOffset = new Vector2(offset, offset);
            
        }
        else
        {
            UI.gameObject.SetActive(false);
            line.enabled = false;
        }
    }
}

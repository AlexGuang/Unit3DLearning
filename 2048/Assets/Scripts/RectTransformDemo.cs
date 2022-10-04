using System.Collections;
using System.Collections.Generic;
using UnityEngine;
///<summary>
///
///</summary>

public class RectTransformDemo : MonoBehaviour
{
    private void Start()
    {
        //世界坐标
        //当画布为overlay 时，世界坐标（单位：米）等同于屏幕坐标（单位：像素）
        //|this.transform.position

        //当前轴心点相对于父UI的位置（单位：像素）
        //this.transform.localPosition
        //RectTransform rtf = GetComponent<RectTransform>();
        RectTransform rtf = this.transform as RectTransform;
        //自身轴心点相对于锚点的位置（编译器中显示的POS)
        //rtf.anchoredPosition3D;、
        //获取/设置锚点
        //rtf.anchorMin
        //获取UI宽度(只读)
        //rtf.rect.width
        //高度
        //rtf.rect.height\

        //设置UI宽度
        //rtf.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal,250)
        //设置UI高度
        //rtf.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical,250);
        //当锚点不分开时，数值可以理解为UI宽高
        //物体大小减去锚点间距
        //size = rtf.sizeDelta
        //RectTransformUtility
    }
}

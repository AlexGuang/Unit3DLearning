using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
///<summary>
///附加到每个方格中，用于定义方格行为
///</summary>

public class NumberSprite : MonoBehaviour
{
    private Image img;
    Vector3 position;
    private void Awake()
    {
        img = GetComponent<Image>();
        position = new Vector3();
    }
    public void SetImage(int number)
    {
        //2 ==>精灵 ===>设置到Image中
        //备注：读取单个精灵使用Load,读取精灵图集使用LoadAll
        img.sprite = ResourceManager.LoadSprite(number);
     
    }

    //移动，合并，生成效果。。。。
    /// <summary>
    /// 生成效果
    /// </summary>
    public void CreateEffect()
    {
        //每个方块生成的时候由小 Vector3.zero ==>大Vector3.one
        
        iTween.ScaleFrom(this.gameObject, Vector3.zero, 0.3f);
     
    }
    //Vector3 ta = new Vector3(1.5f, 1.5f, 1.5f);
    public void MergeEffect()
    {
        iTween.ScaleFrom(gameObject, Vector3.one*2, 0.3f);
    }
    Vector2 moveUpGo = new Vector2(0, 165);
    Vector2 moveDownGo = new Vector3(0, -165,0);
    public void MoveUpEffect()
    {
        iTween.MoveBy(gameObject, moveUpGo, 0.3f);
       // this.transform.Translate(moveDownGo);
      
    }
    public void MoveDownEffect(Vector3 position)
    {

      //  this.transform.position = position;
        iTween.MoveTo(gameObject, position, 0.3f);
        print(position);
    }
    public void MoveUpEffect1(int x)
    {
        iTween.MoveBy(gameObject,new Vector3 (0, 165*x,0), 0.3f);
        // this.transform.Translate(moveDownGo);

    }
    public void MoveUpEffect2(int x)
    {
        iTween.MoveBy(gameObject, new Vector3(0, -165 * x, 0), 0);
        // this.transform.Translate(moveDownGo);

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
///<summary>
///
///</summary>

public class GameBack : MonoBehaviour
{
    private NumberSprite[,] spriteActionArray;
    //private Vector3[,] positions;
    private void Awake()
    {
        spriteActionArray = new NumberSprite[4, 4];
        Init();
      //  positions = new Vector3[4, 4];
    }
    private void Init()
    {
        for (int i = 0; i < 4; i++)
        {
            for (int c = 0; c < 4; c++)
            {
                CreateSprite(i, c);
              //  positions[i, c] = this.transform.position;
            }
        }
    }
    private void CreateSprite(int r, int c)
    {
        //两种方法，一种是通过GameObject创建，另一种方法是通过预制件
        //这是第二种方法，==> Instantiate()
        GameObject go = new GameObject(r.ToString() + c.ToString()+ r.ToString() + c.ToString());
        //读取精灵024816。。。。。
        //设置Image中
        go.AddComponent<Image>();//image 这个类在unityEngine.UI的命名空间下，所以在文件的开头要先引入名字空间。
        NumberSprite actionScript = go.AddComponent<NumberSprite>();//Awake立即执行（在对象创建的瞬间），Start在下一帧以后才执行（在对象被创建后启用时）
        //将引用存储到二维数组中
        spriteActionArray[r, c] = actionScript;
        actionScript.SetImage(0);
        //创建的游戏对象，scale默认为1
        go.transform.SetParent(this.transform, false);
        //print(go.transform.position);
    }

}

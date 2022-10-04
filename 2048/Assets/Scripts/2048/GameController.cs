using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CShartFinalProjectGameOf2048On20200917BasedOnClassAndObject;
using UnityEngine.EventSystems;
using MoveDirection = CShartFinalProjectGameOf2048On20200917BasedOnClassAndObject.MoveDirection;

///<summary>
///游戏控制器
///</summary>

public class GameController : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    private Transform fangkuaiTF;
    public int hangHao;
    public int lieHao;
    private GameCore core;
    private NumberSprite[,] spriteActionArray;
    private Vector3[,] positions;
    public void UpMoveGoGo()
    {
        spriteActionArray[hangHao, lieHao].MoveUpEffect();
    }
    public void DownMoveGoGo()
    {
        spriteActionArray[hangHao, lieHao].MoveDownEffect(positions[hangHao, lieHao]);
    }


    private void Start()
    {
        core = new GameCore();
        spriteActionArray = new NumberSprite[4, 4];
        positions = new Vector3[4, 4];

        Init();

        GenerateNewNumber();
        GenerateNewNumber();
    }
    /// <summary>
    /// 初始化
    /// </summary>
    private void Init()
    {
        for (int i = 0; i < 4; i++)
        {
            for (int c = 0; c < 4; c++)
            {
                CreateSprite(i, c);
                //  string str = i.ToString() + c.ToString() + i.ToString() + c.ToString();
                //  positions[i, c] = GameObject.Find(str).transform.position;
                //print(positions[i, c]);
            }
        }
    }
    /// <summary>
    /// 找到那个方块的位置
    /// </summary>
    private void FindTheLocation()
    {

    }
    /// <summary>
    /// 创建一个精灵
    /// </summary>
    /// <param name="r">精灵的行号</param>
    /// <param name="c">精灵的列号</param>
    private void CreateSprite(int r, int c)
    {
        //两种方法，一种是通过GameObject创建，另一种方法是通过预制件
        //这是第二种方法，==> Instantiate()
        GameObject go = new GameObject(r.ToString() + c.ToString());
        //读取精灵024816。。。。。
        //设置Image中
        go.AddComponent<Image>();//image 这个类在unityEngine.UI的命名空间下，所以在文件的开头要先引入名字空间。
        NumberSprite actionScript = go.AddComponent<NumberSprite>();//Awake立即执行（在对象创建的瞬间），Start在下一帧以后才执行（在对象被创建后启用时）
        //将引用存储到二维数组中
        spriteActionArray[r, c] = actionScript;
        actionScript.SetImage(0);
        //创建的游戏对象，scale默认为1
        go.transform.SetParent(this.transform, false);
    }
    private void GenerateNewNumber()
    {
        //位置？
        //数字？
        EmptyLocation? newNumLocation;
        int? number;

        core.GenerateNewNum(out newNumLocation, out number);
        //根据位置获取精灵行为脚本对象引用
        spriteActionArray[newNumLocation.Value.Rindex, newNumLocation.Value.Cindex].SetImage(number.Value);
        spriteActionArray[newNumLocation.Value.Rindex, newNumLocation.Value.Cindex].CreateEffect();

    }
    private bool isCharge = false;
   // private IEnumerator IfChangeOrNot()
    //{
      //  yield return new WaitForSeconds(0.3f);
      //  if (core.IfChange)
       // {            
         //   isCharge = true;
       // }
    //}
    private void Update()
    {
        //StartCoroutine(IfChangeOrNot());
       // MoveMap();
        //如果地图有更新
        if (core.IfChange)
       // if (isCharge)
        {   
            
            //移动界面   
            
            //MoveMap();
          //  yield return new WaitForSeconds(0.3f);
           //System.Threading.Thread.Sleep(1000);
            //回归界面
           // 
            //更新界面
            
            UpdateMap();
           // ReturnMap();
            core.ClearAllMoveLocation();

            //产生新数字
            GenerateNewNumber();
            //判断又移动了没
            core.IfChange = false;
            //isCharge = false;
            //判断游戏是否结束
            //core.Isover?

        }
    }
    private void MoveMap()
    {
        for (int i = 0; i < core.moveOne.Count; i++)
        {
            spriteActionArray[core.moveOne[i].Rindex, core.moveOne[i].Cindex].MoveUpEffect1(1);
        }
        for (int i = 0; i < core.moveTwo.Count; i++)
        {
            spriteActionArray[core.moveTwo[i].Rindex, core.moveTwo[i].Cindex].MoveUpEffect1(2);
        }
        for (int i = 0; i < core.moveThree.Count; i++)
        {
            spriteActionArray[core.moveThree[i].Rindex, core.moveThree[i].Cindex].MoveUpEffect1(3);
        }
       // yield return new WaitForFixedUpdate();
    }
    private void ReturnMap()
    {
        for (int i = 0; i < core.moveOne.Count; i++)
        {
            spriteActionArray[core.moveOne[i].Rindex, core.moveOne[i].Cindex].MoveUpEffect2(1);
        }
        for (int i = 0; i < core.moveTwo.Count; i++)
        {
            spriteActionArray[core.moveTwo[i].Rindex, core.moveTwo[i].Cindex].MoveUpEffect2(2);
        }
        for (int i = 0; i < core.moveThree.Count; i++)
        {
            spriteActionArray[core.moveThree[i].Rindex, core.moveThree[i].Cindex].MoveUpEffect2(3);
        }
    }
    private void UpdateMap()
    {
       // yield return MoveMap();
        for (int r = 0; r < 4; r++)
        {
            for (int c = 0; c < 4; c++)
            {
                spriteActionArray[r, c].SetImage(core.Map[r, c]);
                              
            }
        }
        if (core.IsMerge)
        {
            for (int i = 0; i < core.mergeLocation.Count; i++)
            {

                spriteActionArray[core.mergeLocation[i].Rindex, core.mergeLocation[i].Cindex].MergeEffect();
            }
            core.mergeLocation.Clear();

        }
      //  ReturnMap();

    }
    private Vector2 startPoint;
    private bool IsDown= false;
    public void OnPointerDown(PointerEventData eventData)
    {
        startPoint = eventData.position;
        IsDown = true;
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (IsDown == false)
        {
            return;
        }
        Vector2 offset = eventData.position - startPoint;
        float x = Mathf.Abs(offset.x);
        float y = Mathf.Abs(offset.y);
        CShartFinalProjectGameOf2048On20200917BasedOnClassAndObject.MoveDirection? dir= null;
        //水平
        if (x > y&& x>=50)
        {
            dir = offset.x > 0 ? CShartFinalProjectGameOf2048On20200917BasedOnClassAndObject.MoveDirection.Right:CShartFinalProjectGameOf2048On20200917BasedOnClassAndObject.MoveDirection.Left;
        }
        //垂直
        if (y > x&&y>50)
        {
            dir = offset.y > 0 ? CShartFinalProjectGameOf2048On20200917BasedOnClassAndObject.MoveDirection.Up : CShartFinalProjectGameOf2048On20200917BasedOnClassAndObject.MoveDirection.Down;
        }
        if (dir != null)
        {
            core.Move(dir.Value);
            IsDown = false;
           
            //ReturnMap();
            


        }
        
    }
}

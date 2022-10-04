using System.Collections;
using System.Collections.Generic;
using UnityEngine;
///<summary>
///资源管理类，负责管理加载资源
///</summary>

public class ResourceManager : MonoBehaviour
{
    private static Dictionary<int, Sprite> spriteDic;
    //类被加载时调用
    static ResourceManager()
    {
        spriteDic = new Dictionary<int, Sprite>();
        var spriteArray = Resources.LoadAll<Sprite>("2048atlas");
        foreach (var item in spriteArray)
        {
            int intSpriteName = int.Parse(item.name);
            spriteDic.Add(intSpriteName, item);
        }
    }
    /// <summary>
/// 读取数字精灵
/// </summary>
/// <param name="number">精灵表示的数字</param>
/// <returns>精灵</returns>
   public static Sprite LoadSprite(int number)
    {

        //foreach (var item in spriteArray)
        //{
        //    if (item.name == number.ToString())
        //    {
        //        return item;
        //    }


        //}
        //return null;
        return spriteDic[number];

    }
}

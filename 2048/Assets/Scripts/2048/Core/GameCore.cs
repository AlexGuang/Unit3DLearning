using System;
using System.Collections.Generic;


namespace CShartFinalProjectGameOf2048On20200917BasedOnClassAndObject
{
    /// <summary>
    /// 游戏核心类，负责处理游戏核心算法，与界面无关
    /// 
    /// </summary>
    /// 

    //哈哈哈 霍巴特时间2020/09/20，17.50圆满完成，练习了
    /// 类，字段，属性，构造函数，集合list,枚举，switch语句，
    /// 访问权限哈哈哈，终于可以进军Unity 脚本了哈哈哈哈哈
    /// 吃个饭回来进军脚本！耶耶耶
    class GameCore
    {

        #region 声明字段
       // private EmptyLocation newNumLocation;
        private int[] copyArray;
        private int[] mergeArray;
        private int[,] map;
        private Random random;
        private int[,] mapCopy;
        private List<EmptyLocation> emptyLocationList;
        private bool ifChange;
        private bool ifWin;
        private bool ifLose;
        private int[,] mapUp;
        private int[,] mapDown;
        private int[,] mapLeft;
        private int[,] mapRight;
        private int[] mergeRecord;
        private int zeroCount;
        private int shiyanC;
        private int moveBack;
        
        public List<MergeStructure>mergeLocation;
        public List<MoveStructure> moveOne;
        public List<MoveStructure> moveTwo;
        public List<MoveStructure> moveThree;
        public MergeStructure newMergeLocation;
        public MergeStructure newMergeLocation2;
        private int shiyanB;
        #endregion
        #region 属性区域
        public bool IsMerge { get; set; }
        private int[] CopyArray
        {
            get
            {
                return this.copyArray;
            }

            set
            {
                this.copyArray = value;
            }
        }
        private int[] MergeArray
        {
            get
            {
                return this.mergeArray;
            }
            set
            {
                this.mergeArray = value;
            }
        }
        public bool IfChange
        {
            get { return ifChange; }
            set { this.ifChange = value; }
        }
        public bool IfWin
        {
            get { return ifWin; }
        }
        public bool IfLose
        {
            get { return ifLose; }
            set
            {
                this.ifLose = value;
            }
        }
        public int[,] Map
        {
            get
            {
                return map;
            }
            set
            {
                this.map = value;
            }
        }
        #endregion
        #region 构造函数
        public GameCore()
        {
            //removeZeroArray = new int [4];
            CopyArray = new int[4];
            mergeArray = new int[4];
            map = new int[4,4];
            emptyLocationList = new List<EmptyLocation>(16);
            random = new Random();
            mapCopy = new int[4, 4];
            mapUp = new int[4, 4];
            mapDown = new int[4, 4];
            mapLeft = new int[4, 4];
            mapRight = new int[4, 4];
            //newNumLocation = new EmptyLocation();
            ifLose = false;
            ifWin = false;
             mergeRecord = new int [2];
             
           
            mergeLocation = new List<MergeStructure>(0);
            moveOne = new List<MoveStructure>(0);
            moveTwo = new List<MoveStructure>(0);
            moveThree = new List<MoveStructure>(0);

            newMergeLocation = new MergeStructure();
            newMergeLocation2 = new MergeStructure();
            shiyanC = 0;
            shiyanB = 0;
        }
        #endregion
        //public GameCore(int[] removeZeroArray) : this()
        //{
        //    this.MergeArray = removeZeroArray;



        //}
        //public GameCore(int[] removeZeroArray, int[,] map) : this(removeZeroArray)
        //{
        //    //this.Map = map;

        //    emptyLocationList = new List<EmptyLocation>(16);
        //    random = new Random();
        //    mapCopy = new int[4,4];
        //    mapUp = new int[4, 4];
        //    mapDown = new int[4, 4];
        //    mapLeft = new int[4, 4];
        //    mapRight = new int[4, 4];


        //}
        #region 数组元素变化
        private void RemoveZero()
        {
            for (int i = 0; i < mergeArray.Length - 1; i++)
            {
                int j = i;

                while (mergeArray[i] == 0)
                {

                    mergeArray[i] += mergeArray[j + 1];
                    mergeArray[j + 1] = 0;
                    j++;
                    if (j == 3)
                    {
                        break;
                    }

                }
            }
        }
        private int zeroCountForward = 0;
        private int zeroFei = 0;
        public void ClearAllMoveLocation()
        {
            moveOne.Clear();
            moveTwo.Clear();
            moveThree.Clear();
        }
        private void FindZero(int c )
        {
            
        }
        private void RemoveZeroCopy()
        {
            Array.Clear(copyArray, 0, 4);
            int index1 = 0;
            for (int i = 0; i < mergeArray.Length; i++)
            {

                if (mergeArray[i] != 0)
                {
                    copyArray[index1++] = mergeArray[i];//0202
                }

            }
            copyArray.CopyTo(mergeArray, 0);
        }
        private void MergeArrayTogether()
        {
            
            
            RemoveZeroCopy();
            zeroCount = 0;
            shiyanC = 0;
            shiyanB = 0;
            for (int i = 0; i < mergeArray.Length - 1; i++)
            {
                if ( mergeArray[i] != 0)
                {
                    if (mergeArray[i] == mergeArray[i + 1])
                    {
                        shiyanC++;
                        shiyanB = i;
                        IsMerge = true;
                        mergeArray[i] += mergeArray[i];
                        mergeArray[i + 1] = 0;
                        // mergeRecord[IndexOfMergeRecord++] = i;
                    }

                }
                else
                {
                    zeroCount++;
                }

            }
            RemoveZeroCopy();
            moveBack = zeroCount;
        }
        #endregion
        #region 移动数组
        private void MoveUp()//00 10 20,30
        {
            IsMerge = false;
            // mergeLocation.Clear();
            for (int c = 0; c < map.GetLength(1); c++)//各个列

            {
                //IndexOfMergeRecord = 0;
                //Array.Clear(mergeRecord, 0, 2);
                for (int r = 0; r < map.GetLength(0); r++)//行
                {
                    mergeArray[r] = map[r, c];

                }
                zeroCountForward = 0;
                for (int i = 0; i < mergeArray.Length; i++)
                {
                    if (mergeArray[i] == 0)
                    {
                        zeroCountForward++;

                    }
                    else
                    {
                        //zeroFei++;
                        if (zeroCountForward != 0)
                        {
                            if (zeroCountForward == 1)
                            {
                                moveOne.Add(new MoveStructure(i, c));
                            }
                            else if (zeroCountForward == 2)
                            {
                                moveTwo.Add(new MoveStructure(i, c));
                            }
                            else if (zeroCountForward == 3)
                            {
                                moveThree.Add(new MoveStructure(i, c));
                            }
                            //moveList(zeroCountForward).ADD(map[c, i]);
                        }
                    }
                }
                MergeArrayTogether();
               
                
                for (int r = 0; r < map.GetLength(0); r++)
                {
                    map[r, c] = mergeArray[r];
                }
                //从这里开始是试验区
                if (IsMerge)
                {
                    if (shiyanC == 1)
                    {
                        if (shiyanB == 0)
                        {
                            //newMergeLocation.Cindex = c;
                            // newMergeLocation.Rindex = 0;
                            // mergeLocation.Add(newMergeLocation);
                            mergeLocation.Add(new MergeStructure(0, c));
                        }
                        else if (shiyanB == 1)
                        {
                            // newMergeLocation.Cindex = c;
                            // newMergeLocation.Rindex = 1;
                            // mergeLocation.Add(newMergeLocation);
                            mergeLocation.Add(new MergeStructure(1, c));
                        }
                        else
                        {
                            // newMergeLocation.Cindex = c;
                            // newMergeLocation.Rindex = 2;
                            // mergeLocation.Add(newMergeLocation);
                            mergeLocation.Add(new MergeStructure(2, c));
                        }

                    }
                    if (shiyanC == 2)
                    {
                        //newMergeLocation.Cindex = c;
                        //  newMergeLocation.Rindex = 0;
                        // mergeLocation.Add(newMergeLocation);
                        // newMergeLocation2.Cindex = c;
                        //  newMergeLocation2.Rindex = 1;
                        // mergeLocation.Add(newMergeLocation2);
                        mergeLocation.Add(new MergeStructure(0, c));
                        mergeLocation.Add(new MergeStructure(1, c));

                    }
                }
                


            }
        }
        private void JudgeMoveUp()//00 10 20,30
        {
            for (int c = 0; c < mapUp.GetLength(1); c++)//各个列

            {
                for (int r = 0; r < mapUp.GetLength(0); r++)//行
                {
                    mergeArray[r] = mapUp[r, c];

                }
                MergeArrayTogether();
                for (int r = 0; r < mapUp.GetLength(0); r++)
                {
                    mapUp[r, c] = mergeArray[r];
                }


            }
        }
        private void MoveDown()//00 10 20,30
        {
            IsMerge = false;

            for (int c = 0; c < map.GetLength(1); c++)//各个列

            {
                for (int r = 0; r < map.GetLength(0); r++)//行
                {
                    mergeArray[r] = map[3 - r, c];

                }
                MergeArrayTogether();
                for (int r = 0; r < map.GetLength(0); r++)
                {
                    map[3 - r, c] = mergeArray[r];
                }


            }
        }
        private void JudgeMoveDown()//00 10 20,30
        {
            for (int c = 0; c < mapDown.GetLength(1); c++)//各个列

            {
                for (int r = 0; r < mapDown.GetLength(0); r++)//行
                {
                    mergeArray[r] = mapDown[3 - r, c];

                }
                MergeArrayTogether();
                for (int r = 0; r < mapDown.GetLength(0); r++)
                {
                    mapDown[3 - r, c] = mergeArray[r];
                }


            }
        }
        public void MoveLeft()//00 10 20,30
        {
            for (int r = 0; r < map.GetLength(1); r++)//各个行

            {
                for (int c = 0; c < map.GetLength(0); c++)//列
                {
                    mergeArray[c] = map[r, c];

                }
                MergeArrayTogether();
                for (int c = 0; c < map.GetLength(0); c++)
                {
                    map[r, c] = mergeArray[c];
                }

            }
        }
        private void JudgeMoveLeft()//00 10 20,30
        {
            for (int r = 0; r < mapLeft.GetLength(1); r++)//各个行

            {
                for (int c = 0; c < mapLeft.GetLength(0); c++)//列
                {
                    mergeArray[c] = mapLeft[r, c];

                }
                MergeArrayTogether();
                for (int c = 0; c < mapLeft.GetLength(0); c++)
                {
                    mapLeft[r, c] = mergeArray[c];
                }

            }
        }
        private void MoveRight()//00 10 20,30
        {
            for (int r = 0; r < map.GetLength(1); r++)//各个行

            {
                for (int c = 0; c < map.GetLength(0); c++)//列
                {
                    mergeArray[c] = map[r, 3 - c];

                }
                MergeArrayTogether();
                for (int c = 0; c < map.GetLength(0); c++)
                {
                    map[r, 3 - c] = mergeArray[c];
                }


            }
        }
        private void JudgeMoveRight()//00 10 20,30
        {
            for (int r = 0; r < mapRight.GetLength(1); r++)//各个行

            {
                for (int c = 0; c < mapRight.GetLength(0); c++)//列
                {
                    mergeArray[c] = mapRight[r, 3 - c];

                }
                MergeArrayTogether();
                for (int c = 0; c < mapRight.GetLength(0); c++)
                {
                    mapRight[r, 3 - c] = mergeArray[c];
                }


            }
        }
        public void Move(MoveDirection direction)
        {
            
            Array.Copy(map, mapCopy, 16);
            
            switch ((int)direction)
            {
                case 0:
                    MoveUp();
                    break;
                case 2:
                    MoveDown();
                    break;
                case 4:
                    MoveLeft();
                    break;
                case 8:
                    MoveRight();
                    break;


            }
            
            ifChange = false;
            for (int r = 0; r < map.GetLength(0); r++)
            {
                for (int c = 0; c < map.GetLength(1); c++)
                {
                    if (mapCopy[r, c] != map[r, c])
                    {
                       ifChange = true;
                        break;
                    }
                    
                }
                if (ifChange == true)
                {
                    break;
                }
            }
            

            


        }
        #endregion
        #region 加随机新数

        public void GetEmptyLocationList()
        {

            emptyLocationList.Clear();
            for (int r = 0; r < map.GetLength(0); r++)
            {
                for (int c = 0; c < map.GetLength(1); c++)
                {
                    if (map[r,c] == 0)
                    {
                        emptyLocationList.Add(new EmptyLocation(r, c));
                    }
                    
                }
                
            }
        }

        public void GenerateNewNum(out EmptyLocation? newNumLocation, out int? number)
        {
            GetEmptyLocationList();
            if (emptyLocationList.Count > 0)
            {
                int listIndex = random.Next(0, emptyLocationList.Count - 1);
                newNumLocation = emptyLocationList[listIndex];
                number = map[newNumLocation.Value.Rindex, newNumLocation.Value.Cindex] = random.Next(0, 10) == 1 ? 4 : 2;
            }
            else
            {
                //int? a = null;
                //int?不再是原来的值类型，如果需要获取值类型数据，使用a.Value
                //int?是C#的可空值类型
                newNumLocation = null;
                number = null;
            }
            
        }
        #endregion
        #region 判断输赢
        public void JudgeIfWin( )
        {
            for (int r = 0; r < map.GetLength(1); r++)
            {
                for (int c = 0; c < map.GetLength(0); c++)
                {
                    if (map[r,c] >= 2048)
                    {
                        ifWin = true;
                                             

                    }
                }
            }
        }
        /// <summary>
        /// 判断输有bug,一直没搞出来，具体
        /// 的思想是， 在每次移动后，复制当前的二维数组到
        /// 四个新数组中，如果数组内不含0，也就是满员了
        /// 对四个新数组分别进行上下左右四个
        /// 方向的移动。判断如果移动后四个新数组仍然等于
        /// 原来的数组，说明移不动，各元素无法相加也无法去零，
        /// 认定为游戏失败。
        /// 具体代码没找到bug。心中的痛啊。
        /// </summary>
        /// <returns></returns>
        public bool JudgeIfLose()
        {
            GetEmptyLocationList();
           
            if (emptyLocationList.Count == 0)
            {
                IfLose = true;                                         
                Array.Copy(map, mapDown, 16);
                JudgeMoveDown();
                for (int r = 0; r < map.GetLength(0); r++)
                {
                   
                    for (int c = 0; c < map.GetLength(1); c++)
                    {
                        if (mapDown[r, c] != map[r, c])
                        {
                            IfLose = false;
                            return IfLose;
                        }

                    }

                }
                Array.Copy(map, mapLeft, 16);
                JudgeMoveLeft();
                for (int r = 0; r < map.GetLength(0); r++)
                {
                    for (int c = 0; c < map.GetLength(1); c++)
                    {
                        if (mapLeft[r, c] != map[r, c])
                        {
                            IfLose = false;
                            return IfLose;
                        }

                    }

                }
                Array.Copy(map, mapRight, 16);
                JudgeMoveRight();
                for (int r = 0; r < map.GetLength(0); r++)
                {
                    for (int c = 0; c < map.GetLength(1); c++)
                    {
                        if (mapRight[r, c] != map[r, c])
                        {
                            IfLose = false;
                            return IfLose;
                        }

                    }

                }
                Array.Copy(map, mapUp, 16);
                JudgeMoveUp();
                for (int r = 0; r < map.GetLength(0); r++)
                {
                    for (int c = 0; c < map.GetLength(1); c++)
                    {
                        if (mapUp[r, c] != map[r, c])
                        {
                            IfLose = false;
                            return IfLose;
                        }

                    }

                }

                return IfLose;

            }
            else
                return IfLose;
            

        }
#endregion
    }
}

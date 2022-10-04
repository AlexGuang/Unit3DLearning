using System.Collections;
using System.Collections.Generic;
using UnityEngine;
///<summary>
///
///</summary>
namespace CShartFinalProjectGameOf2048On20200917BasedOnClassAndObject
{
    public struct MoveStructure
    {
        public int Rindex { get; set; }
        public int Cindex { get; set; }
        public MoveStructure(int rindex, int cindex):this()
        {
            this.Rindex = rindex;
            this.Cindex = cindex;
        }
    }
}


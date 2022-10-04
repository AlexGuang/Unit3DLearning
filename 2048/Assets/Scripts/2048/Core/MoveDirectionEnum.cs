using System;
using System.Collections.Generic;

namespace CShartFinalProjectGameOf2048On20200917BasedOnClassAndObject
{
    [Flags]
    enum  MoveDirection:int
    {
     
        Up = 0,
        Down = 2,
        Left = 4,
        Right = 8

    }
}

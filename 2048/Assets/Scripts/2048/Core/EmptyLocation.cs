using System;
using System.Collections.Generic;


namespace CShartFinalProjectGameOf2048On20200917BasedOnClassAndObject
{
    struct EmptyLocation
    {
        public int Rindex { get; set; }
        public int Cindex { get; set; }
        public EmptyLocation(int rindex,int cindex):this()
        {
            this.Rindex = rindex;
            this.Cindex = cindex;
        }
    }
}

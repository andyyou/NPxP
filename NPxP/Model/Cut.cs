using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NPxP.Model
{
    public class Cut
    {
        public double MD { set; get; }
        public bool IsDealed { set; get; }

        public Cut(double md)
        {
            this.MD = md;
            this.IsDealed = false ; // Default is false.
        }
    }
}

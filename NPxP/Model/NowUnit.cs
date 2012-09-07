using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NPxP.Model
{
    public class NowUnit
    {
        public string ComponentName { get; set; }
        public string Symbol { get; set; }
        public double Conversion { get; set; }
        public NowUnit(string name, string symbol, double conversion)
        {
            this.ComponentName = name;
            this.Conversion = conversion;
            this.Symbol = symbol;
        }
    }
}

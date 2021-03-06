﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WRPlugIn;

namespace NPxP.Helper
{
    public static class JobHelper
    {
        public static IList<IFlawTypeName> FlawTypes {set; get;}
        public static IList<ILaneInfo> Lanes { set; get; }
        public static IList<ISeverityInfo> SeverityInfo { set; get; }
        public static IJobInfo JobInfo { set; get; }
        public static IPxPInfo PxPInfo { set; get; }
        public static IWRJob Job;
        public static bool IsOnline { set; get; }
        public static bool IsOnpeHistory { set; get; }

        static JobHelper()
        {
            // Default
            IsOnline = false;
            IsOnpeHistory = false;
        }
    }
}

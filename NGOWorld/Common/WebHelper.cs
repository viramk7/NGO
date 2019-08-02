﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NGOWorld.Common
{
    public static class WebHelper
    {
        public const int PageSize = 25;

        public static int[] PageSizes = { 25, 50 };

        public const string PleaseSelect = "--Select--";

        public static readonly Dictionary<string, object> ActionCenterColumnStyleWithCanEdit = new Dictionary<string, object> { { "align", "center" }, { "style", "text-align:center;vertical-align:middle !important;" }, { "width", "80px" } };

        public static readonly Dictionary<string, object> ActionCenterColumnStyleWithCanStatus = new Dictionary<string, object> { { "align", "center" }, { "style", "text-align:center;vertical-align:middle !important;" }, { "width", "120px" } };

        public static readonly Dictionary<string, object> StatusColumnStyle = new Dictionary<string, object> { { "align", "center" }, { "style", "text-align:center;vertical-align:middle !important;" }, { "width", "60px" } };

        public static readonly Dictionary<string, object> SmallColumnStyle = new Dictionary<string, object> { { "align", "center" }, { "style", "text-align:center;vertical-align:middle !important;" }, { "width", "30px" } };
    }
}

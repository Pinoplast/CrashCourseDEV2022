﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_Cheburashka
{
    interface IHouse
    {
        int Number_floors { set; get; }
        int Number_windows { set; get; }
        void Build(IPerson person, string str);
    }
}
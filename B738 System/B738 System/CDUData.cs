﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B738_System
{
    public abstract class CDUData
    {
        public enum CDUCellFlags
        {
            SmallFont = 1, // small font, including that used for line headers 
            Reverse = 2, // character background is highlighted in reverse video
            Unused = 4 // dimmed character color indicating inop/unused entries
        }

        public enum CDUCellColor
        {
            White = 1,
            Cyan = 2,
            Green = 4,
            Magenta = 8,
            Amber = 16,
            Red = 32
        }

        public struct CDUCellData
        {
            public char S;
            public int C;
            public int F;
        }

        public static uint Columns = 24;
        public static uint Rows = 14;

        public abstract CDUCellData[,] GetData(uint index);
        public abstract void RegisterData(object simConnection);
        public abstract bool ProcessData(object data);

        public abstract void Disconnect();
    }
}

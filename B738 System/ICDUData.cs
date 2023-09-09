using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B738_System
{
    public interface ICDUData
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

            public CDUCellData()
            {
                S = ' ';
                C = 0;
                F = 0;
            }
        }

        public static uint Columns = 24;
        public static uint Rows = 14;

        public void RegisterData(object simconnection);

        public ICDUData.CDUCellData[,] GetData(uint index);
    }
}

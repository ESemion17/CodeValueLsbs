using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryDisplay
{
    public class MyBinaryDisplay
    {
        private int _number;
        public MyBinaryDisplay(int num)
        {
            _number = num;
        }
        public string ConvertToBinary()
        {
            return Convert.ToString(_number, 2);
        }
        public int CountOnes()
        {
            int num = _number;
            int count = 0;
            while (num != 0)
            {
                count += (num & 1);
                num >>= 1;
            }
            return count;
        }

    }
}

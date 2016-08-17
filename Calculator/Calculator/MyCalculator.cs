using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class MyCalculator
    {
        private double _num1;
        private double _num2;
        public MyCalculator(double num1, double num2)
        {
            _num1 = num1;
            _num2 = num2;
        }
        public double Add()
        {
            return _num1 + _num2;
        }
        public double Substract()
        {
            return _num1 - _num2;
        }
        public double Mult()
        {
            return _num1 * _num2;
        }
        public double Divide()
        {
            if (_num2 != 0)
                return _num1 / _num2;
            else
                throw new DivideByZeroException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rationals
{
    struct Rational
    {
        int _numerator;
        int _denominator;
        public Rational(int numerator, int denominator)
        {
            _numerator = numerator;
            _denominator = denominator;
        }
        public Rational(int numerator)
        {
            _numerator = numerator;
            _denominator = 1;
        }
        public int Numerator
        {
            get
            {
                return _numerator;
            }
        }
        public int Denominator
        {
            get
            {
                return _denominator;
            }
        }
        public double DoubleValue
        { 
            get
            {
                return _numerator / (double)_denominator;
            }
        }
        public static Rational Add(Rational r1, Rational r2)
        {
            return new Rational(r1.Numerator * r2.Denominator + r2.Numerator * r1.Denominator, r1.Denominator * r2.Denominator);
        }
        public static Rational Mult(Rational r1, Rational r2)
        {
            return new Rational(r1.Numerator * r2.Numerator, r1.Denominator * r2.Denominator);
        }
        public void Reduce()
        {
            for (int i = _numerator; i > 1; --i)
                if (_numerator%i==0 && _denominator%i==0)
                {
                    _denominator /= i;
                    _numerator /= i;
                }
        }
        public override string ToString()
        {
            return $"{_numerator} / {_denominator}";
        }
        public static Rational operator +(Rational x, Rational y)
        {
            var tmp = new Rational(x.Numerator * y.Denominator + y.Numerator * x.Denominator, x.Denominator * y.Denominator));
            tmp.Reduce();
            return tmp;
        }
        public static Rational operator -(Rational x, Rational y)
        {
            var tmp = new Rational(x.Numerator * y.Denominator - y.Numerator * x.Denominator, x.Denominator * y.Denominator));
            tmp.Reduce();
            return tmp;
        }
        public static Rational operator *(Rational x, Rational y)
        {
            var tmp = new Rational(x.Numerator * y.Numerator, x.Denominator * y.Denominator));
            tmp.Reduce();
            return tmp;
        }
        public static Rational operator /(Rational x, Rational y)
        {
            var tmp = new Rational(x.Numerator * y.Denominator, x.Denominator * y.Numerator));
            tmp.Reduce();
            return tmp;
        }
        public static explicit operator int (Rational r)
        {
            return r.Numerator / r.Denominator;
        }
        public static implicit operator double(Rational r)
        {
            return r.Numerator / (double) r.Denominator;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var rational1 = new Rational(5, 2);
            var rational2 = new Rational(4);
            var rational3 = Rational.Mult(rational1, rational2);
            var rational4 = Rational.Add(rational1, rational2);
            
            Console.Write($"{rational1} * {rational2} =  {rational3}");
            rational3.Reduce();
            Console.WriteLine($" ==> {rational3}");
            Console.WriteLine($"{rational1} + {rational2} =  {rational4}");
            Console.WriteLine($"double value is of {rational4} is {rational4.DoubleValue}");
        }
    }
}

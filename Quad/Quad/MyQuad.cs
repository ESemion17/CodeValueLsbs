using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quad
{
    public class MyQuad
    {
        private double _a;
        private double _b;
        private double _c;
        public MyQuad(double[] coeff)
        {
            _a = coeff[0];
            _b = coeff[1];
            _c = coeff[2];
        }
        private double DiscriminantCalc()
        {
            var ans = _b * _b;
            ans -= 4 * _a * _c;
            return ans;
        }
        public List<double> Solve()
        {
            var ans = new List<double>();
            var dis = DiscriminantCalc();
            if (dis == 0)
                ans.Add(_b / (2 * (-_a)));
            if (dis > 0)
            {
                ans.Add((_b + Math.Sqrt(dis)) / (2 * (-_a)));
                ans.Add((_b - Math.Sqrt(dis)) / (2 * (-_a)));
            }
            return ans;
        }
        public override string ToString()
        {
            return $"{_a}*x^2 + {_b}*x + {_c} = 0";
        }
    }
}

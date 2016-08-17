using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncDemo
{
    public partial class Form1 : Form
    {
        // bad name !!
        private delegate IEnumerable<int> _delegate(int frist,int last);
        public Form1()
        {
            InitializeComponent();
        }

        private IEnumerable<int> CalcPrimes(int frist, int last)
        {
            var list = new List<int>();
            for (int i = frist; i <= last; i++)
                if (Ispraim(i))
                    list.Add(i);
            return list;
        }

        private bool Ispraim(int num)
        {
            if (num < 2)
                return false;
            if (num == 2)
                return true;
            var lastToCheck = (int)Math.Round(Math.Sqrt(num) + 0.5);
            for (int i = 2; i <= lastToCheck; i++)
                if (num % i == 0)
                    return false;
            return true;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            _delegate del = CalcPrimes;
            // Perfect ... but next time use TryParse and validate your input!
            del.BeginInvoke(int.Parse(textBox1.Text),int.Parse(textBox2.Text),(asyncRes) =>
            {
                var answer = del.EndInvoke(asyncRes).ToArray<int>();
                var test = new string[answer.Length];
                for (int i = 0; i < answer.Length; i++)
                {
                    test[i] = answer[i].ToString();
                }
                listBox1.BeginInvoke(new Action(() => 
                {
                    listBox1.Items.AddRange(test);
                }));
            }, null);
        }
    }
}

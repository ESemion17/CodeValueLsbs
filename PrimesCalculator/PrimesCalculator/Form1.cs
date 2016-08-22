using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrimesCalculator
{
    public partial class Form1 : Form
    {
        CancellationTokenSource _cts;
        CancellationToken _token;

        public Form1()
        {
            InitializeComponent();
            _cts = new CancellationTokenSource();
            _token = _cts.Token;
        }

        private void calcButton_Click(object sender, EventArgs e)
        {
            var t1 = new Thread(()=>CalcPrimes(int.Parse(textBox1.Text), int.Parse(textBox2.Text), _token));
            t1.Start();
        }

        private void CalcPrimes(int first, int last, CancellationToken token)
        {
            for (int i = first; i <= last && !token.IsCancellationRequested; i++)
                if (Ispraim(i))
                    listBox1.Invoke(new Action(() => listBox1.Items.Add(i)));
            if (token.IsCancellationRequested)
            {
                MessageBox.Show("Was canceled");
                return;
            }

            MessageBox.Show("Done");
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

        private void cancelButton_Click(object sender, EventArgs e)
        {
            _cts.Cancel();
        }
        ~Form1()
        {
            _cts.Dispose();
        }
    }
}

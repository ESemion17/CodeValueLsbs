using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MailSystem
{
    public class Program
    {
        static void Main(string[] args)
        {
            var mailManager = new MailManager();
            mailManager.MailArrived+=Display;
            var mailArrivedEventArgs = new MailArrivedEventArgs("First Title",1);
            TimerCallback tcb = mailManager.SimulateMailArrived;
            var stateTimer = new Timer(tcb, mailArrivedEventArgs, 1000, 1000);
            Console.ReadLine();
            stateTimer.Dispose();
        }

        private static void Display(object sender, MailArrivedEventArgs e)
        {
            Console.WriteLine($"Title: {e.Title}");
            Console.WriteLine($"Body: {e.Body}");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSystem
{
    public class MailArrivedEventArgs
    {
        public MailArrivedEventArgs(string title, int body)
        {
            Title = title;
            Body = body;
        }

        public string Title { get; }
        public int Body { get; }
    }
}

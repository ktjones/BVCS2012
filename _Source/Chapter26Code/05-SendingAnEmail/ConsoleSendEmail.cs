using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _05_SharedInterfaces;

namespace _05_SendingAnEmail
{
    public class ConsoleSendEmail : ISendEmail
    {
        public void SendEmail(string sender, string recipient, string subject, string body)
        {
            Console.WriteLine("Email to:      {0}", recipient);
            Console.WriteLine("      from:    {0}", sender);
            Console.WriteLine("      subject: {0}", subject);
            Console.WriteLine("      body:    {0}", body);
        }
    }
}

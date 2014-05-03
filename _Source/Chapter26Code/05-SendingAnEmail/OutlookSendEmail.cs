using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _05_SharedInterfaces;
using Microsoft.Office.Interop.Outlook;

namespace _05_SendingAnEmail
{
    public class OutlookSendEmail : ISendEmail
    {
        public void SendEmail(string sender, string recipient, string subject, string body)
        {
            // Uncomment this to get it to work with Outlook!
            //Application app = new Application();
            //var mapi = app.GetNamespace("MAPI");
            //mapi.Logon(ShowDialog: false, NewSession: false);
            //var outbox = mapi.GetDefaultFolder(OlDefaultFolders.olFolderOutbox);

            //MailItem email = app.CreateItem(OlItemType.olMailItem) as MailItem;
            //email.To = recipient;
            //email.Subject = subject;
            //email.Body = body;
            //// Can use the following but you get a warning that this is ambiguous
            ////email.Send();
            //// So I use this, rather less pretty code
            //((Microsoft.Office.Interop.Outlook._MailItem)email).Send();
        }
    }
}

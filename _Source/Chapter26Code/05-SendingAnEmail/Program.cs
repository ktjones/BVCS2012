using System;
using System.Linq;
using System.Activities;
using System.Activities.Statements;
using System.Threading;

namespace _05_SendingAnEmail
{

    class Program
    {
        static void Main(string[] args)
        {
            WorkflowApplication app = new WorkflowApplication(new Workflow1());
            app.Extensions.Add(new ConsoleSendEmail());
//            app.Extensions.Add(new OutlookSendEmail());
            ManualResetEvent finished = new ManualResetEvent(false);
            app.Completed = (completedArgs) => { finished.Set(); };
            app.Run();
            finished.WaitOne();
        }
    }
}

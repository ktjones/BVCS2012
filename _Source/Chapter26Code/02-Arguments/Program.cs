using System;
using System.Linq;
using System.Activities;
using System.Activities.Statements;
using System.Collections.Generic;

namespace _02_Arguments
{

    class Program
    {
        static void Main(string[] args)
        {
            // Create and cache the workflow definition
            Activity workflow1 = new Workflow1();
            Dictionary<string, object> parms = new Dictionary<string, object>();
            parms.Add("Name", "Morgan");
            WorkflowInvoker.Invoke(workflow1, parms);
            Console.ReadLine();
        }
    }
}

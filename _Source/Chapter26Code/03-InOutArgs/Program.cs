using System;
using System.Linq;
using System.Activities;
using System.Activities.Statements;
using System.Collections.Generic;

namespace _03_InOutArgs
{

    class Program
    {
        static void Main(string[] args)
        {
            // Create and cache the workflow definition
            Dictionary<string, object> parms = new Dictionary<string, object>();
            parms.Add("Person", "Morgan");
            Activity workflow1 = new Workflow1();

            foreach (KeyValuePair<string, object> kvp in
                WorkflowInvoker.Invoke(workflow1, parms))
            {
                Console.WriteLine("{0} = {1}", kvp.Key, kvp.Value);
            }
        }
    }
}

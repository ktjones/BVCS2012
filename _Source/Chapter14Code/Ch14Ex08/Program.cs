using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace Ch14Ex08
{
   class Program
   {
      static void Main(string[] args)
      {
         DisplayCallerInformation();
         Action callerDelegate = new Action(() => DisplayCallerInformation());
         callerDelegate();
         CallerHelper(callerDelegate);
         Caller();
         DisplayCallerInformation(3, "Bob", @"C:\Temp\NotRealCode.cs");
         Console.ReadKey();
      }

      static void CallerHelper(Action callToMake)
      {
         callToMake();
      }

      static void Caller()
      {
         DisplayCallerInformation();
      }

      static void DisplayCallerInformation(
         [CallerLineNumber] int callerLineNumber = 0,
         [CallerMemberName] string callerMemberName = "",
         [CallerFilePath] string callerFilePath = "")
      {
         Console.WriteLine(
            string.Format(
               "Method called from line {0} of member {1} in file {2}.",
               callerLineNumber,
               callerMemberName,
               callerFilePath));
      }
   }
}

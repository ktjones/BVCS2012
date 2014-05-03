using System;
using System.Activities;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _05_SharedInterfaces;

namespace _05_CustomActivities
{
    [Designer("_05_CustomActivities.Design.SendEmailDesigner, 05-CustomActivities.Design")]
    public class SendEmail : NativeActivity
    {
        public InArgument<string> Sender { get; set; }
        
        [RequiredArgument]
        public InArgument<string> Recipient { get; set; }
        
        [RequiredArgument]
        public InArgument<string> Subject { get; set; }

        [RequiredArgument]
        public InArgument<string> Body { get; set; }

        protected override void Execute(NativeActivityContext context)
        {
            context.GetExtension<ISendEmail>().SendEmail(Sender.Get(context), Recipient.Get(context), Subject.Get(context), Body.Get(context));
        }
    }
}

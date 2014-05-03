using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EventRegistration
{
    public partial class ResultsPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                RegistrationInfo ri = PreviousPage.RegistrationInfo;

                labelResult.Text = String.Format("{0} {1} selected the event {2}",
                    ri.FirstName, ri.LastName, ri.SelectedEvent);
            }
            catch
            {
                labelResult.Text = "The originating page must contain " +
                      "textFirstName, textLastName, textEmail controls";
            }
        }
    }
}
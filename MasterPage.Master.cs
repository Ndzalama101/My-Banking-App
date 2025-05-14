using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KingstonBankl
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Get the current page name
                string currentPage = System.IO.Path.GetFileName(Request.Url.AbsolutePath).ToLower();

                // Define the visibility settings for each page
                var pageSettings = new Dictionary<string, (bool, bool, bool, bool)>
                {
                    { "index.aspx", (false, false, true, true) },
                    { "loginpage.aspx", (true, false, true, false) },
                    { "registrationpage.aspx", (true, false, false, true) },
                    { "adminlogin.aspx", (true, false, true, false) },
                    { "userpage.aspx", (false, true, false, false) },
                    { "usereditinfopage.aspx", (false, true, false, false) },
                    { "adminhomepage.aspx", (false, true, false, false) },
                    { "admineditinfo.aspx", (false, true, false, false) },
                    { "transactionspage.aspx", (false, true, false, false) },
                };

                // Default visibility settings
                bool showHomeLink = false;
                bool showLogoutLink = false;
                bool showSignUpLink = false;
                bool showLoginLink = false;

                // Check if the current page is in the dictionary
                if (pageSettings.ContainsKey(currentPage))
                {
                    var settings = pageSettings[currentPage];
                    showHomeLink = settings.Item1;
                    showLogoutLink = settings.Item2;
                    showSignUpLink = settings.Item3;
                    showLoginLink = settings.Item4;
                }

                // Apply the visibility settings
                homeLink.Visible = showHomeLink;
                LogoutLink.Visible = showLogoutLink;
                SignUpLink.Visible = showSignUpLink;
                LoginLink.Visible = showLoginLink;
            }

        }

        
    }
}
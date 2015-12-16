/**
* Author: Yi Zhao
*
* Description: This page adds log out feature
*
*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace test
{
    /// <summary>
    /// Checks user login status, users have to login before proceed to any other pages,
    /// and provides option to logout.
    /// </summary>
    public class Auth
    {
        /// <summary> Location of log in page.</summary>
        private const string LOGIN_PAGE = "LogIn_Miranda.aspx";


        private string _userName;
        private bool _isLoggedIn = false;

        /// <summary>
        /// Stores and reads user name from session variable.
        /// </summary>
        public string userName
        {
            get
            {
                return (String)HttpContext.Current.Session["userName"];
            }
            set
            {
                _userName = value;
                HttpContext.Current.Session["userName"] = value;
            }
        }

        /// <summary>
        /// Stores and reads log in status from session variable.
        /// </summary>
        public bool isLoggedIn
        {
            get
            {
                if (HttpContext.Current.Session["logInStatus"] != null)
                {
                    return (Boolean)HttpContext.Current.Session["logInStatus"];
                }
                else
                {
                    return false;
                }
            }
            set
            {
                _isLoggedIn = value;
                HttpContext.Current.Session["logInStatus"] = value;
            }
        }

        /// <summary>
        /// Stores the page before user is forced to redirected to log in page.
        /// </summary>
        private string _currentPage = Path.GetFileName(HttpContext.Current.Request.Url.AbsolutePath);
        

        /// <summary>
        /// Constructor with empty parameter. It checks log in status
        /// </summary>
        public Auth()
        {
            logIncheck();
        }

        /// <summary>
        /// Logs in the user that has been passed in, 
        /// redirects user to the page he/she was trying to open before log in.
        /// </summary>
        /// <param name="name">user name that will be shown on the page </param>
        public Auth(string name)
        {
            userName = name;
            isLoggedIn = true;
            redirect();
        }

        /// <summary>
        /// If user is not logged in, redirects to log in page,
        /// adds current page as query string, so it can be used to 
        /// direct user back the page he/she tried to open.
        /// </summary>
        private void logIncheck()
        {
            if(!isLoggedIn && _currentPage != LOGIN_PAGE)
            {
                HttpContext.Current.Response.Redirect(LOGIN_PAGE + "?r=" + _currentPage );
            }
        }
        
        /// <summary>
        /// Sends user back to the page before login.
        /// </summary>
        private void redirect()
        {
            if(HttpContext.Current.Request.QueryString["r"] != null)
            {
                HttpContext.Current.Response.Redirect(HttpContext.Current.Request.QueryString["r"]);
            }
        }
        
        /// <summary>
        /// Logs out current user, and go to login page.
        /// </summary>
        public void logOut()
        {
            isLoggedIn = false;
            HttpContext.Current.Response.Redirect(LOGIN_PAGE);
        }
    }
}
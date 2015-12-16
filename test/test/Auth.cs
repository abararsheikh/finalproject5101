using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace test
{
    public class Auth
    {
        private const string LOGIN_PAGE = "LogIn_Miranda.aspx";
        private string _userName;
        private bool _isLoggedIn = false;

        public Auth()
        {
            logIncheck();
        }

        public Auth(string name)
        {
            userName = name;
            isLoggedIn = true;
        }

        public void logIncheck()
        {
            if(!isLoggedIn && Path.GetFileName( HttpContext.Current.Request.Url.AbsolutePath) != LOGIN_PAGE)
            {
                HttpContext.Current.Response.Redirect(LOGIN_PAGE + "?r=true" );
            }
        }

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

        public void logOut()
        {
            isLoggedIn = false;
            HttpContext.Current.Response.Redirect(LOGIN_PAGE);
        }
    }
}
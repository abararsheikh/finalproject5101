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
        private string _currentPage = Path.GetFileName(HttpContext.Current.Request.Url.AbsolutePath);
        


        public Auth()
        {
            logIncheck();
        }

        public Auth(string name)
        {
            userName = name;
            isLoggedIn = true;
            redirect();
        }

        private void logIncheck()
        {

            if(!isLoggedIn && _currentPage != LOGIN_PAGE)
            {
                HttpContext.Current.Response.Redirect(LOGIN_PAGE + "?r=" + _currentPage );
            }
        }
        
        private void redirect()
        {
            if(HttpContext.Current.Request.QueryString["r"] != null)
            {
                HttpContext.Current.Response.Redirect(HttpContext.Current.Request.QueryString["r"]);
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
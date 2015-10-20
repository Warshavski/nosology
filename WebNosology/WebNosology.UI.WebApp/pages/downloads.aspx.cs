﻿using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace WebNosology.UI.WebApp.pages
{
    public partial class downloads : System.Web.UI.Page
    {

        protected void Page_Init(object sender, EventArgs e)
        {
            this.signOutLink.ServerClick += (send, args) =>
            {
                FormsAuthentication.SignOut();
                Response.Redirect("pages/login.aspx");
            };
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string[] splitedString = Context.User.Identity.Name.Split('#');

            this.userName.Text = splitedString[0];
            this.userLevel.Text = string.Format("Уровень : {0}", splitedString[1]);
        }
    }
}

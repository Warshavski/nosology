﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Escyug.Nosology.MVP.UI.WebApp.pages.templates
{
    public partial class fileDownloadTemplate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.ContentType = "application/txt";
            // filename in which 
            Response.AppendHeader("Content-Disposition", "attachment; filename=MyFile.txt");

            // Write the file to the Response
            const int bufferLength = 10000;
            byte[] buffer = new Byte[bufferLength];
            int length = 0;
            Stream download = null;
            try
            {
                download = new FileStream(Server.MapPath("~/App_Data/main.txt"),FileMode.Open,FileAccess.Read);
                do
                {
                    if (Response.IsClientConnected)
                    {
                        length = download.Read(buffer, 0, bufferLength);
                        Response.OutputStream.Write(buffer, 0, length);
                        buffer = new Byte[bufferLength];
                    }
                    else
                    {
                        length = -1;
                    }
                }
                while (length > 0);
                Response.Flush();
                Response.End();
            }
            finally
            {
                if (download != null)
                    download.Close();
            }
        }
    }
}
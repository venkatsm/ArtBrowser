﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ArtGallery.Common
{
    public static class Global
    {
        public static string ImagesPath
        {
            get
            {
                return ConfigurationManager.AppSettings["Images_Location"].ToString();
            }
        }

        public static int PaginationSize
        {
            get
            {
                return Convert.ToInt32(ConfigurationManager.AppSettings["PaginationSize"]);
            }
        }

        public static string EmailFrom
        {
            get
            {
                return ConfigurationManager.AppSettings["emailFrom"];
            }
        }

        public static string EmailSentFrom
        {
            get
            {
                return ConfigurationManager.AppSettings["emailSentFrom"];
            }
        }

        public static string EmailPassword
        {
            get
            {
                return ConfigurationManager.AppSettings["emailPassword"];
            }
        }

        public static string EmailSmtpClient
        {
            get
            {
                return ConfigurationManager.AppSettings["emailSmtpClient"];
            }
        }

        public static int EmailPort
        {
            get
            {
                return Convert.ToInt32(ConfigurationManager.AppSettings["emailPort"]);
            }
        }
    }
}
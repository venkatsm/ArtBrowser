using System;
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
    }
}
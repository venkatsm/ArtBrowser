using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ArtGallery.Data.DAL;

namespace ArtGallery.Models
{
    public class ArtBrowserDBContext:DbContext
    {
        public DbSet<Artist> Artists { set; get; }
    }
}
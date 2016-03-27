using ArtGallery.Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtGallery.Models
{
    public class HomeViewModel
    {
        public List<Event> Events { get; set; }

        public List<FeaturedPartner> Partners { get; set; }
    }
}
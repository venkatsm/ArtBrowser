using ArtGallery.Data.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArtGallery.Models
{
    public class ArtsViewModel :Art
    {
        private ArtBrowserDBContext db = new ArtBrowserDBContext();
        public ArtsViewModel()
        {
            this.Categories = new SelectList(db.Categories, "CategoryId", "Name");
            this.Locations = new SelectList(db.Locations, "LocationId", "Name");
            this.Art_Images = new List<string>();

        }

        private SelectList _Locations;
        private SelectList _Categories;        
        private List<string> _Art_Images;
        
        public SelectList Locations
        {
            get
            {
                return _Locations;
            }

            set
            {
                _Locations = value;
            }
        }

        public SelectList Categories
        {
            get
            {
                return _Categories;
            }

            set
            {
                _Categories = value;
            }
        }

        [Display(Name = "Art Images")]
        public List<string> Art_Images
        {
            get
            {
                return _Art_Images;
            }

            set
            {
                _Art_Images = value;
            }
        }
    }
}
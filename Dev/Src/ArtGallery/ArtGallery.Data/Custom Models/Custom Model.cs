using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtGallery.Data.DAL
{
    [MetadataType(typeof(ExhibitionMetadata))]
    public partial class Exhibition
    {
        internal sealed class ExhibitionMetadata
        {
            [Display(Name = "Image")]
            public string ImagePath { get; set; }

            [Required]
            [Display(Name ="Start Date")]
            [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
            [DataType(DataType.Date)]
            public DateTime StartDate { get; set; }

            [Required]
            [Display(Name = "End Date")]
            [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
            [DataType(DataType.Date)]
            public DateTime EndDate { get; set; }
        }
    }

    [MetadataType(typeof(EventMetadata))]
    public partial class Event
    {
        internal sealed class EventMetadata
        {
            [Display(Name = "Image")]
            public string ImagePath { get; set; }

            [Required]
            [Display(Name = "Start Date")]
            [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
            [DataType(DataType.Date)]
            public DateTime StartDate { get; set; }

            [Required]
            [Display(Name = "End Date")]
            [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
            [DataType(DataType.Date)]
            public DateTime EndDate { get; set; }

            [Display(Name ="Set as Featured")]
            public Nullable<bool> DisplayInHomePage { get; set; }
        }
    }


    [MetadataType(typeof(ArtistMetadata))]
    public partial class Artist
    {
        public IEnumerable<Art> Arts { get; set; }

        public Exhibition LatestExhibition { get; set; }

        internal sealed class ArtistMetadata
        {
            //[Required]
            public string Location { get; set; } = string.Empty;

            //[Required]
            public string Statement { get; set; } = string.Empty;

            //[Required]
            [Display(Name = "Price Range")]
            public string Price_Range { get; set; } = string.Empty;

            public string Gender { set; get; }

            [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
            [DataType(DataType.Date)]
            public DateTime DOB { set; get; }
        }
    }

    [MetadataType(typeof(ArtMetadata))]
    public partial class Art
    {
        internal sealed class ArtMetadata
        {
            [Display(Name = "Category")]
            public int Category_ID { get; set; }

            [Display(Name = "Location")]
            public Nullable<int> Location_ID { get; set; }

            [Display(Name = "Cover Image")]
            public string Cover_Pic_Path { get; set; }

            [Required]
            public string Title { get; set; }

            //[Required]
            public string Subject { get; set; }

            [Required]
            public string Price { get; set; }

            [Required]
            public string Size { get; set; }

            [Required]
            public string Medium { get; set; }
        }
    }

    [MetadataType(typeof(InstitutionMetadata))]
    public partial class Institution
    {
        public IEnumerable<Art> Arts { get; set; }

        public Exhibition LatestExhibition { get; set; }

        internal sealed class InstitutionMetadata
        {
            //[Required]
            [Display(Name = "Price Range")]
            public string Price_Range { get; set; } = string.Empty;

            //[Required]
            public string Location { get; set; } = string.Empty;

            //[Required]
            [Display(Name = "About Us")]
            public string Aboutus { get; set; } = string.Empty;

            //[Required]
            public string InstitutionType { get; set; } = string.Empty;

            //[Required]
            public string ContactUs { get; set; } = string.Empty;
        }
    }
}

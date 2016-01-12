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
            [Required]
            [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
            [DataType(DataType.Date)]
            public DateTime StartDate { get; set; }

            [Required]
            [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
            [DataType(DataType.Date)]
            public DateTime EndDate { get; set; }
        }
    }


    [MetadataType(typeof(ArtistMetadata))]
    public partial class Artist
    {
        public IEnumerable<Art> Arts { get; set; }

        public Exhibition LatestExhibition { get; set; }

        internal sealed class ArtistMetadata
        {
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
       }
    }

    [MetadataType(typeof(InstitutionMetadata))]
    public partial class Institution
    {
        public IEnumerable<Art> Arts { get; set; }

        public Exhibition LatestExhibition { get; set; }

        internal sealed class InstitutionMetadata
        {
            
        }
    }
}

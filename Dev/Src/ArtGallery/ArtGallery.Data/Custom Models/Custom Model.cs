using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtGallery.Data.DAL
{
    [MetadataType(typeof(ArtistMetadata))]
    public partial class Artist
    {
        internal sealed class ArtistMetadata
        {
            public string Gender { set; get; }

            [DataType(DataType.Date)]
            public DateTime DOB { set; get; }
        }
    }

    

    [MetadataType(typeof(InstitutionMetadata))]
    public partial class Institution
    {
        internal sealed class InstitutionMetadata
        {
            
        }
    }
}

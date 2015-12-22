using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtGallery.Models
{
    public class Enums
    {
    }

    public enum PartnerType
    {
        Artist,
        Institution
    }

    public enum UserType
    {
        Administrator,
        Artist,
        Institution,
        Buyer
    }
}
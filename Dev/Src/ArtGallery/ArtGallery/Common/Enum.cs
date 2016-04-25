using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ArtGallery.Common
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
        Buyer,
        Administrator,
        Artist,
        Institution
    }

    public enum StatusType
    {
        Draft,
        Submitted,
        Rejected,
        Approved,
        Published,
        PendingApproval,
    }
}
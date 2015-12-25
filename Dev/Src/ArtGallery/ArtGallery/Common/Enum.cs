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
        Administrator,
        Artist,
        Institution,
        Buyer
    }

    public enum StatusType
    {
        Draft,
        Submitted,
        Rejected,
        Published,
        [Description("Pending Approval")]
        PendingApproval,
    }
}
﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using ArtGallery.Common;

namespace ArtGallery.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }

        public string ApprovalStatus { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            this.ApprovalStatus = this.ApprovalStatus ?? StatusType.PendingApproval.ToString();
            // Add custom user claims here
            userIdentity.AddClaim(new Claim("DisplayName", this.Name));
            userIdentity.AddClaim(new Claim("ApprovalStatus", this.ApprovalStatus));
            userIdentity.AddClaim(new Claim("EmailConfirmed", this.EmailConfirmed.ToString()));

            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("IdentityDbContext", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
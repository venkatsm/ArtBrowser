using ArtGallery.Common;
using ArtGallery.Data.DAL;
using ArtGallery.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ArtGallery.Extensions
{
    public static class UserManagerExtensions
    {
        public async static Task<IdentityResult> AddUserToRole(this ApplicationUserManager manager, ApplicationUser user, string role, DateTime DOB)
        {
            ArtBrowserDBContext db = new ArtBrowserDBContext();
            UserType Role = ((UserType)Enum.Parse(typeof(UserType), role));

            switch (Role)
            {
                case UserType.Artist:
                    db.Artists.Add(new Artist() { User_ID = user.Id, DOB = DOB });
                    break;
                case UserType.Institution:
                    db.Institutions.Add(new Institution() { User_ID = user.Id });
                    break;
            }

            db.SaveChanges();
            return await manager.AddToRoleAsync(user.Id, role);
        }
    }
}
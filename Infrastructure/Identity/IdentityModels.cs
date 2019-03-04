﻿using Infrastructure.Enum;
using Infrastructure.Enums;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Infrastructure.Identity
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        #region propreties

        [StringLength(255)]
        public string Avatar { get; set; }

        [StringLength(255)]
        public string Wallpaper { get; set; }

        [Display(Name = "Địa chỉ")]
        [StringLength(100)]
        public string Address { get; set; }

        [Display(Name = "Giới tính")]
        public GenderEnum Gender { get; set; }

        [StringLength(100)]
        [Display(Name = "Họ và tên")]
        public string FullName { get; set; }

        [Display(Name = "Trạng thái")]
        public StatusEnum Status { get; set; }

        #endregion propreties

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
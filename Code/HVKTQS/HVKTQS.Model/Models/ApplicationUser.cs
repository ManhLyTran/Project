using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HVKTQS.Model.Models
{
    public partial class ApplicationUser : IdentityUser
    {
        public int EmployeeID { set; get; }

        [MaxLength(255)]
        public string FullName { set; get; }

        [MaxLength(255)]
        public string Address { set; get; }

        public DateTime? BirthDay { set; get; }

        public string LastIPAddress { get; set; }

        public bool? IsLock { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }

        public virtual IEnumerable<EventUser> EventUsers { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace VetsJobFinder.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class SiteUser : IdentityUser
    {
       
        [Required]
        [MaxLength(25)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(30)]
        public string LastName { get; set; }

        public string CompanyName { get; set; }

        public bool IsEmployer { get; set; }

        public string Resume { get; set; }

        public virtual ICollection<ApplyJob>  JobsAppliedFor { get; set; } = new List<ApplyJob>();

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<SiteUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public enum ApplyStatus
    {
        Applied,
        EmployerDeclined,
        EmployerAccepted,
        ApplicantDeclined,
    }
    public class ApplyJob
    {
        public int Id { get; set; }
        public Job Job { get; set; }
        public SiteUser Applicant { get; set; }

        public DateTime AppliedOn { get; set; }
        public DateTime StatusDate { get; set; }
        public ApplyStatus Status { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<SiteUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

    }
}
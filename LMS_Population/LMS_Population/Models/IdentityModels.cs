using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using LMS_Population.Models.CourseData;
using LMS_Population.Models.UserData;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LMS_Population.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class LMS_PopulationDbContext : IdentityDbContext<ApplicationUser>
    {
        public LMS_PopulationDbContext()
            : base("LMS_PopulationDbContext", throwIfV1Schema: false)
        {

        }

        

        public static LMS_PopulationDbContext Create()
        {
            return new LMS_PopulationDbContext();
        }

        public DbSet <Course> Course { get; set; }

        public DbSet<BooleanQuestion> BooleanQuestion { get; set; }

        public DbSet<Page> Page { get; set; }

        public DbSet<PageField> PageField { get; set; }

        public DbSet<QuestionChoice> QustionChoice { get; set; }

        public DbSet<TabField> TabField { get; set; }

        public DbSet<TestAnswer> TestAnswer { get; set; }

        public DbSet<TestQuestion> TestQuestion { get; set; }


    }
}
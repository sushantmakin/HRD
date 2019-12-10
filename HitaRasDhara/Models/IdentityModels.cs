using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace HitaRasDhara.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
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

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<UserResponse5Aug> UserResponse5Aug { get; set; }
        public DbSet<SMSContent> SmsContent { get; set; }
        public DbSet<EventFeedbackViewModel> Feedback5August { get; set; }
        public DbSet<QueryViewModel> QueryForm { get; set; }
        public DbSet<UpcomingKathaItem> UpcomingKathaFeed { get; set; }
        public DbSet<SadhakSanjeevaniItem> SadhakSanjeevaniFeed { get; set; }
        public DbSet<QuestionsViewModel> EventQuestionsForm { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
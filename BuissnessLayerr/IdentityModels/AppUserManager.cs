using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace BuissnessLayer.IdentityModels
{
    public class AppUserManager: UserManager<AppUser>
    {
        public AppUserManager(IUserStore<AppUser> store)
        : base(store)
        {
        }

        public static AppUserManager Create(
      IdentityFactoryOptions<AppUserManager> options, IOwinContext context)
        {
            var manager = new AppUserManager(
                new UserStore<AppUser>(context.Get<ApplicationContext>()));

            // optionally configure your manager
            // ...

            return manager;
        }
    }
}

using Microsoft.AspNet.Identity;
using System;
using TekENotionsWebApp.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Threading.Tasks;

namespace TekENotionsWebApp.Authentication
{
    public class AuthRepository : IDisposable
    {
        private AuthContext db = new AuthContext();

        private UserManager<IdentityUser> _userManager;

        public AuthRepository()
        {
           
            _userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(db));
        }

        public async Task<IdentityResult> RegisterUser(UserModel userModel)
        {
            IdentityUser user = new IdentityUser
            {
                UserName = userModel.UserName
            };
            var test = await _userManager.FindAsync(user.UserName, userModel.Password);

            var result = await _userManager.CreateAsync(user, userModel.Password);

            return result;
        }

        public async Task<IdentityUser> FindUser(string userName, string password)
        {
            IdentityUser user = await _userManager.FindAsync(userName, password);
            return user;
        }
        public void Dispose()
        {
            db.Dispose();
            _userManager.Dispose();
        }
    }
}
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using CorePRactice1.Models;

namespace CorePRactice1.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> CreateUserAsync(SignUpUserModel userModel);
    }
}
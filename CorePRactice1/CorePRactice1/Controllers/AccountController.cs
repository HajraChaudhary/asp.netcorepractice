using CorePRactice1.Models;
using CorePRactice1.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorePRactice1.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
      _accountRepository = accountRepository;
        }

        [Route("Signup")]
        public IActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        [Route("Signup")]
        public async Task<IActionResult> Signup(SignUpUserModel userModel)
        {
            if (ModelState.IsValid)
            {

                var result = await _accountRepository.CreateUserAsync(userModel);
                if (!result.Succeeded)
                {
                    foreach (var errorMessage in result.Errors)
                    { ModelState.AddModelError("", errorMessage.Description);  }
                
                }
                ModelState.Clear();
            }
            return View();
        }
    }
}

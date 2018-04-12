using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QuestApp.Models;

namespace QuestApp.Controllers
{
    public class AccountController : Controller
    {
        
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [Route("/login")]
        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost("/login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            Console.WriteLine(model);
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Inf", "Home");
                }
                else
                {
                    return Json("Invalid login attempt");

                }
            }
            return View(model);


        }
      
        public IActionResult Register(string returnUrl = null)
        {
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(Register model)
        {
           
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    
                    return RedirectToAction("Login");
                }
                return Json("Invalid register attempt");
            }

            // If we got this far, something failed, redisplay form
            return View();
        }
        public async Task<IActionResult> Logout()
        {

            await _signInManager.SignOutAsync();
            return RedirectToAction("Register");
        }

    }
}

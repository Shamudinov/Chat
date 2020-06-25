using System;
using AutoMapper;
using Chat.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Chat.Models.AuthorizationViewModels;
using Microsoft.AspNetCore.Authorization;

namespace Chat.Controllers
{
    [Authorize]
    public class AuthorizationController : Controller
    {
        private IMapper _mapper;
        private SignInManager<User> _signInManager;
        private UserManager<User> _userManager;
        private RoleManager<IdentityRole> _roleManager;


        public AuthorizationController(UserManager<User> userManager, IMapper mapper, 
                                        SignInManager<User> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _mapper = mapper;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Authorization() => View();
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Authorization(RegisterViewModel register)
        {
            if (ModelState.IsValid)
            {
                register.Birthday = DateTime.Now;

                var user = _mapper.Map<RegisterViewModel, User>(register);

                var result = await _userManager.CreateAsync(user, register.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction();
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(register);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login() => View();       
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel Login)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(Login.Email);
                
                if (user != null)
                {
                    await _signInManager.SignOutAsync();
                    var result = await _signInManager.PasswordSignInAsync(user, Login.Password, false, false);
                    
                    if (result.Succeeded)
                    {
                        return View("Authorization");
                    }
                }
            }
            return View();
        }

        // Mabe замучу роли но вряд ли 
        //[HttpGet]
        //[Authorize]
        //public IActionResult ToTieRole() => View();
        //[HttpPost]
        //[Authorize]
        //public async Task<IActionResult> ToTieRole(userId, roleId)
        //{
        //    return View();
        //}
    }
}

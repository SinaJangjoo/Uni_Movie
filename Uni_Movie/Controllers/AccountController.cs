using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Uni_Movie.Areas.Identity.Data;
using Uni_Movie.Middleware;
using Uni_Movie.Utilities;
using Uni_Movie.ViewModels;

namespace Uni_Movie.Controllers
{
	public class AccountController : Controller
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly SignInManager<ApplicationUser> _signInManager;
		private readonly RoleManager<IdentityRole> _roleManager;

		public AccountController(UserManager<ApplicationUser> userManager,
			SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_roleManager = roleManager;
		}

		[HttpGet]
		public async Task<IActionResult> Register()
		{
			await DbSeeder.IdentityInitializer(_userManager, _roleManager);
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Register(RegisterViewModel model)
		{
			if (ModelState.IsValid)
			{
				ApplicationUser user = await _userManager.FindByNameAsync(model.EmailAddress);
				if (user == null)
				{
					user = new()
					{
						Email = model.EmailAddress,
						FirstName = model.Firstname,
						LastName = model.Lastname,
						UserName = model.EmailAddress
					};
					var result = await _userManager.CreateAsync(user, model.Password);
					var roleStatus = await _userManager.AddToRoleAsync(user, SD.Role_Customer);
					if (result.Succeeded && roleStatus.Succeeded)
					{
						TempData["success"] = "! You have been registered successfully";
						return RedirectToAction("Index", "Home");
					}
					else
					{
						TempData["error"] = "! There was an error in registeration process";
					}
				}
				else
				{
					TempData["error"] = "! This user already exists";
				}
				return View(model);
			}
			else
			{
				return View(model);
			}
		}

		public IActionResult Login() => View();

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Login(LoginViewModel model)
			{
			if (ModelState.IsValid)
			{
				var user = await _userManager.FindByNameAsync(model.EmailAddress);
				if (user != null)
				{
					var result = await _signInManager.PasswordSignInAsync(user, model.password, false, false);
					if (result.Succeeded)
					{

						TempData["success"] = "! Successfully Logged in";
						return RedirectToAction("Index", "Home");
					}
					else
					{
						ModelState.AddModelError("EmailAddress", "Invalid Username or Password");
						return View(model);
					}
				}
				else
				{
					ModelState.AddModelError("EmailAddress", "Invalid Username or Password");
					return View(model);
				}
			}
			else
			{
				return View(model);
			}
		}
	}
}

using Microsoft.AspNetCore.Identity;
using Uni_Movie.Areas.Identity.Data;
using Uni_Movie.Utilities;

namespace Uni_Movie.Middleware
{
	public static class DbSeeder
	{
		public static async Task IdentityInitializer(UserManager<ApplicationUser> userManager,
			RoleManager<IdentityRole> roleManager)
		{
			List<string> roles = new() { SD.Role_Admin, SD.Role_Customer };
			foreach (var item in roles)
			{
				if ((await roleManager.RoleExistsAsync(item) == false))
				{
					IdentityRole identityRole = new (item);
					await roleManager.CreateAsync(identityRole);
				}
			}
			ApplicationUser admin = await userManager.FindByNameAsync("admin@gmail.com");
			if (admin == null)
			{
				admin = new ApplicationUser()
				{
					UserName = "admin@gmail.com",
					Email = "admin@gmail.com",
					EmailConfirmed = true,
					PhoneNumber = "09014460701",
					PhoneNumberConfirmed = true,
					FirstName = "owner",
					LastName = "owner",
				};
				await userManager.CreateAsync(admin, "Admin123*");
				if (await userManager.IsInRoleAsync(admin, SD.Role_Admin) == false)
				{
					await userManager.AddToRoleAsync(admin, SD.Role_Admin);
				}
			}
		}
	}
}

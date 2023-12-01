using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Uni_Movie.ViewModels
{
	public class LoginViewModel
	{
        [Required(ErrorMessage ="Please enter Username / Email Address")]
        public string EmailAddress { get; set; }
        [Required(ErrorMessage ="Please enter Password")]
        public string password { get; set; }
    }
}

﻿using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Uni_Movie.ViewModels
{
	public class RegisterViewModel
	{
		[Required]
		public string Firstname { get; set; }
		[Required]
		public string Lastname { get; set; }
		[Required]
		public string EmailAddress { get; set; }
		[Required]
		public string Password { get; set; }
	}
}

﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Uni_Movie.ViewModels
{
    public class MovieCreateViewModel
    {
        public MovieViewModel movie { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> genreList { get; set; }

    }
}

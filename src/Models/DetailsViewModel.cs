using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcMovie.Models
{
    public class DetailsViewModel
    {
        public EmailViewModel EmailVM { get; set; }
        public MovieViewModel MovieViewModel { get; set; }
    }
}
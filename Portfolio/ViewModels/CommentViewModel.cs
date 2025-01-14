﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.ViewModels
{
    public class CommentViewModel
    {
        public int CommentId { get; set; }
        public int BlogId { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateSubmitted { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
        [EmailAddress]
        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }
        [Display(Name = "Comment")]
        public string CommentText { get; set; }
    }
}

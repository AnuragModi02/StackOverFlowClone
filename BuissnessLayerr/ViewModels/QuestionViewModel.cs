using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BuissnessLayer.ViewModels
{
    public class QuestionViewModel
    {
        [Required]
        public string Title { get; set; }

        [Required]        
        public string Question { get; set; }

        public string Tags { get; set; }
    }
}

using BuissnessLayer.IdentityModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuissnessLayer.Models
{
    public class Question
    {
        public int Id { get; set; }

        public string Questions { get; set; }

        public string Description { get; set; }

        public List<Answer> Answers { get; set; }

        public Category Category { get; set; }

        public AppUser Appuser { get; set; }

        public int Votes { get; set; }

        public List<Tags> Tags { get; set; }

    }
}

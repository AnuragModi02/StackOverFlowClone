using System;
using System.Collections.Generic;
using System.Text;

namespace BuissnessLayer.Models
{
    public class Answer
    {
        public int Id { get; set; }

        public string Answers{ get; set; }

        public Question Question { get; set; }

        public User User { get; set; }

        public int Votes { get; set; }
    }
}

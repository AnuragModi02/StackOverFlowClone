using BuissnessLayer.IdentityModels;

namespace BuissnessLayer.Models
{
    public class Answer
    {
        public int Id { get; set; }

        public string Answers{ get; set; }

        public Question Question { get; set; }

        public AppUser Appuser { get; set; }

        public int Votes { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace BuissnessLayer.Models
{
    public class Tags
    {
        public int Id { get; set; }

        public string TagName { get; set; }

        public Question question { get; set; }


    }
}

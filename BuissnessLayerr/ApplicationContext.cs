
using BuissnessLayer.IdentityModels;
using BuissnessLayer.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BuissnessLayer
{
    public class ApplicationContext : IdentityDbContext<BuissnessLayer.IdentityModels.AppUser>
    {
        public ApplicationContext() : base("name=DBConnectionString")
        {

        }

        public DbSet<Question> Questions { get; set; }

        public DbSet<Answer> Answers { get; set; }

        public DbSet<Category> Categories { get; set; }
    }
}
using Bliss.Recruitment.Simple.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bliss.Recruitment.Simple.Data.Context
{
    public class RecruitmentContext : DbContext
    {
        public DbSet<Question> Questions { get; set; }
        public DbSet<Choice> Choices { get; set; }

        public RecruitmentContext(DbContextOptions<RecruitmentContext> options)
              : base(options)
        {
            this.ChangeTracker.AutoDetectChangesEnabled = false;
            this.ChangeTracker.LazyLoadingEnabled = true;
        }
    }
}

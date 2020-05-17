using ASPNET.DTO;
using Microsoft.EntityFrameworkCore;
using System;

namespace AspNetdbContext
{
    public class AspContext: DbContext
    {
        public AspContext(DbContextOptions<AspContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();

        }
        public virtual DbSet<Post> Post { get; set; }
        public virtual DbSet<Vote> Vote { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Comments> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<User>(enti => {
                enti.HasKey(e => e.UserID);
                
            });

            modelBuilder.Entity<Post>(enti => {
                enti.HasKey(e => e.PostID);
                enti.Ignore(d => d.NumberOfComments);


            });
            modelBuilder.Entity<Vote>(enti => {
                enti.HasKey(e => e.VoteID);
                enti.HasOne(d => d.Comments)
                    .WithMany(p => p.Vote)
                    .HasForeignKey(d => d.CommentsID);
            });
            modelBuilder.Entity<Comments>(enti => {
                enti.HasKey(e => e.CommentsID);
                enti.HasOne(d => d.Post)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.PostID);
                enti.Ignore(d => d.NumberOfDisLike);
                enti.Ignore(d => d.NumberOfLike);

            });
        }


    }
}

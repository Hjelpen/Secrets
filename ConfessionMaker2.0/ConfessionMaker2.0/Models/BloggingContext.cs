using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfessionMaker2._0.Models
{
    public partial class BloggingContext : DbContext
    {
        public DbSet<Post> Post { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<CommentReply> CommentReplies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=LAPTOP-7FTNR3A6\SQLEXPRESS;Database=Blogging;Trusted_Connection=True;");
            }
        }

        public BloggingContext(DbContextOptions<BloggingContext> options)
        : base(options)
        { }

        public BloggingContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}


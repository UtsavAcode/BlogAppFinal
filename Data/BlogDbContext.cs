    using BlogApp.Model.Domain;
    using Microsoft.EntityFrameworkCore;

    namespace BlogApp.Data
    {
        public class BlogDbContext:DbContext
        {
            public BlogDbContext(DbContextOptions<BlogDbContext> options) :base (options) 
            {
            
            }

            public DbSet<BlogPost> BlogPosts { get; set; }
            public DbSet<Tag> Tags { get; set; }
            public DbSet<BlogLike> Likes { get; set; }
            public DbSet<BlogComment> Comments { get; set; }
            public DbSet<BlogView> BlogViews { get; set; }
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);

                // Configure relationships for Likes
                modelBuilder.Entity<BlogLike>()
                   .HasKey(l => new { l.BlogPostId, l.UserId });

                modelBuilder.Entity<BlogComment>(entity =>
                {
                    entity.HasKey(bc => bc.Id); // Primary key for BlogComment

                    // Configure one-to-many relationship with BlogPost
                    entity.HasOne(bc => bc.BlogPost)
                          .WithMany(bp => bp.Comments)
                          .HasForeignKey(bc => bc.BlogPostId);

                    // Ensure the Content field is required with a maximum length
                    entity.Property(bc => bc.Content)
                          .IsRequired()
                          .HasMaxLength(1000);

                    // UserId will now be a string and not a foreign key
                    entity.Property(bc => bc.UserId)
                          .IsRequired(); // Ensure UserId is required
                });

            modelBuilder.Entity<BlogView>()
                   .HasKey(v => v.Id); // Primary Key

            modelBuilder.Entity<BlogView>()
                .HasOne(v => v.BlogPost)
                .WithMany(bp => bp.BlogView)
                .HasForeignKey(v => v.BlogPostId);

        }
    }
    }

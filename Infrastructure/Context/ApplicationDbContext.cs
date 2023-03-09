using Core.Interfaces;
using Core.Models;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        
        private readonly IDateTimeService _dateTimeService;
        public static string Schema => "dbo";


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IDateTimeService dateTimeService) : base(options)
        {
            _dateTimeService = dateTimeService;
        }


        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<PostTag> PostTags { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Tag>()
                .HasIndex(t => t.Name)
                .IsUnique();

            modelBuilder.Entity<Tag>()
               .Property(c => c.Id)
               .ValueGeneratedOnAdd();

            modelBuilder.Entity<Category>()
                .Property(c => c.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Post>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<PostTag>()
                .HasKey(pt => new { pt.PostId, pt.TagId });

            modelBuilder.Entity<PostTag>()
                .HasOne(pt => pt.Post)
                .WithMany(p => p.PostTags)
                .HasForeignKey(pt => pt.PostId);

            modelBuilder.Entity<PostTag>()
                .HasOne(pt => pt.Tag)
                .WithMany(t => t.PostTags)
                .HasForeignKey(pt => pt.TagId);

            base.OnModelCreating(modelBuilder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {

            foreach (var entry in ChangeTracker.Entries<IAuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedAt = _dateTimeService.UtcNow;
                        break;
                    case EntityState.Modified:
                        entry.Entity.ModifiedAt = _dateTimeService.UtcNow;
                        break;
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}

using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Pisheyar.Application.Common.Interfaces;
using Pisheyar.Domain.Common;
using Pisheyar.Domain.Entities;

namespace Pisheyar.Infrastructure.Persistence
{
    public partial class PisheyarContext : DbContext, IPisheyarContext
    {
        //private readonly ICurrentUserService _currentUser;
        private readonly IDateTime _dateTime;

        public PisheyarContext()
        {
        }

        public PisheyarContext(
            DbContextOptions<PisheyarContext> options,
            //ICurrentUserService currentUserService,
            IDateTime dateTime) : base(options)
        {
            //_currentUser = currentUserService;
            _dateTime = dateTime;
        }

        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<Advertisement> Advertisement { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<CategoryTag> CategoryTag { get; set; }
        public virtual DbSet<ChatMessage> ChatMessage { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Code> Code { get; set; }
        public virtual DbSet<CodeGroup> CodeGroup { get; set; }
        public virtual DbSet<Comment> Comment { get; set; }
        public virtual DbSet<ContactUs> ContactUs { get; set; }
        public virtual DbSet<Contractor> Contractor { get; set; }
        public virtual DbSet<ContractorCategory> ContractorCategory { get; set; }
        public virtual DbSet<Document> Document { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderRequest> OrderRequest { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }
        public virtual DbSet<Permission> Permission { get; set; }
        public virtual DbSet<PermissionGroup> PermissionGroup { get; set; }
        public virtual DbSet<Post> Post { get; set; }
        public virtual DbSet<PostCategory> PostCategory { get; set; }
        public virtual DbSet<PostComment> PostComment { get; set; }
        public virtual DbSet<PostTag> PostTag { get; set; }
        public virtual DbSet<Province> Province { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<RolePermission> RolePermission { get; set; }
        public virtual DbSet<SmsProviderConfiguration> SmsProviderConfiguration { get; set; }
        public virtual DbSet<SmsProviderNumber> SmsProviderNumber { get; set; }
        public virtual DbSet<SmsResponse> SmsResponse { get; set; }
        public virtual DbSet<SmsSetting> SmsSetting { get; set; }
        public virtual DbSet<SmsTemplate> SmsTemplate { get; set; }
        public virtual DbSet<Tag> Tag { get; set; }
        public virtual DbSet<Token> Token { get; set; }
        public virtual DbSet<Transaction> Transaction { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserPermission> UserPermission { get; set; }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        //entry.Entity.CreatedBy = _currentUser.UserId;
                        entry.Entity.Created = _dateTime.Now;
                        break;
                    case EntityState.Modified:
                        //entry.Entity.LastModifiedBy = _currentUser.UserId;
                        entry.Entity.LastModified = _dateTime.Now;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Seed();

            base.OnModelCreating(modelBuilder);
        }

        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

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
    public class PisheyarMagContext : DbContext, IPisheyarMagContext
    {
        //private readonly ICurrentUserService _currentUserService;
        private readonly IDateTime _dateTime;

        public PisheyarMagContext()
        {
        }

        public PisheyarMagContext(
            DbContextOptions<PisheyarMagContext> options,
            //ICurrentUserService currentUserService,
            IDateTime dateTime) : base(options)
        {
            //_currentUserService = currentUserService;
            _dateTime = dateTime;
        }

        public virtual DbSet<TblCategory> TblCategory { get; set; }

        public virtual DbSet<TblCode> TblCode { get; set; }

        public virtual DbSet<TblCodeGroup> TblCodeGroup { get; set; }

        public virtual DbSet<TblComment> TblComment { get; set; }

        public virtual DbSet<TblPermission> TblPermission { get; set; }

        public virtual DbSet<TblPost> TblPost { get; set; }

        public virtual DbSet<TblPostCategory> TblPostCategory { get; set; }

        public virtual DbSet<TblPostComment> TblPostComment { get; set; }

        public virtual DbSet<TblPostTag> TblPostTag { get; set; }

        public virtual DbSet<TblRole> TblRole { get; set; }

        public virtual DbSet<TblRolePermission> TblRolePermission { get; set; }

        public virtual DbSet<TblSmsproviderConfiguration> TblSmsproviderConfiguration { get; set; }

        public virtual DbSet<TblSmsproviderNumber> TblSmsproviderNumber { get; set; }

        public virtual DbSet<TblSmsresponse> TblSmsresponse { get; set; }

        public virtual DbSet<TblSmssetting> TblSmssetting { get; set; }

        public virtual DbSet<TblSmstemplate> TblSmstemplate { get; set; }

        public virtual DbSet<TblTag> TblTag { get; set; }

        public virtual DbSet<TblUser> TblUser { get; set; }

        public virtual DbSet<TblUserPermission> TblUserPermission { get; set; }

        public virtual DbSet<TblUserToken> TblUserToken { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        //entry.Entity.CreatedBy = _currentUserService.UserId;
                        entry.Entity.Created = _dateTime.Now;
                        break;
                    case EntityState.Modified:
                        //entry.Entity.LastModifiedBy = _currentUserService.UserId;
                        entry.Entity.LastModified = _dateTime.Now;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            builder.Seed();

            base.OnModelCreating(builder);
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("Server=.;Database=PisheyarMag;Trusted_Connection=True;");
        //    }
        //}
    }
}

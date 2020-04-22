using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Pisheyar.Domain.Entities;

namespace Pisheyar.Application.Common.Interfaces
{
    public interface IPisheyarMagContext
    {
        DbSet<TblChatMessage> TblChatMessage { get; set; }

        DbSet<TblChatRoom> TblChatRoom { get; set; }

        DbSet<TblAdvertisement> TblAdvertisement { get; set; }

        DbSet<TblCategory> TblCategory { get; set; }

        DbSet<TblCategoryTag> TblCategoryTag { get; set; }

        DbSet<TblCode> TblCode { get; set; }

        DbSet<TblCodeGroup> TblCodeGroup { get; set; }

        DbSet<TblComment> TblComment { get; set; }

        DbSet<TblDocument> TblDocument { get; set; }

        DbSet<TblPermission> TblPermission { get; set; }

        DbSet<TblPost> TblPost { get; set; }

        DbSet<TblPostCategory> TblPostCategory { get; set; }

        DbSet<TblPostComment> TblPostComment { get; set; }

        DbSet<TblPostTag> TblPostTag { get; set; }

        DbSet<TblRole> TblRole { get; set; }

        DbSet<TblRolePermission> TblRolePermission { get; set; }

        DbSet<TblSmsproviderConfiguration> TblSmsproviderConfiguration { get; set; }

        DbSet<TblSmsproviderNumber> TblSmsproviderNumber { get; set; }

        DbSet<TblSmsresponse> TblSmsresponse { get; set; }

        DbSet<TblSmssetting> TblSmssetting { get; set; }

        DbSet<TblSmstemplate> TblSmstemplate { get; set; }

        DbSet<TblTag> TblTag { get; set; }

        DbSet<TblUser> TblUser { get; set; }

        DbSet<TblUserPermission> TblUserPermission { get; set; }

        DbSet<TblUserToken> TblUserToken { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

        int SaveChanges();
    }
}

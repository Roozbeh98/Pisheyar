using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Pisheyar.Domain.Entities;

namespace Pisheyar.Application.Common.Interfaces
{
    public interface IPisheyarContext
    {
        DbSet<Admin> Admin { get; set; }
        DbSet<Advertisement> Advertisement { get; set; }
        DbSet<Category> Category { get; set; }
        DbSet<CategoryTag> CategoryTag { get; set; }
        DbSet<ChatMessage> ChatMessage { get; set; }
        DbSet<City> City { get; set; }
        DbSet<Client> Client { get; set; }
        DbSet<Code> Code { get; set; }
        DbSet<CodeGroup> CodeGroup { get; set; }
        DbSet<Comment> Comment { get; set; }
        DbSet<ContactUs> ContactUs { get; set; }
        DbSet<Contractor> Contractor { get; set; }
        DbSet<ContractorCategory> ContractorCategory { get; set; }
        DbSet<Document> Document { get; set; }
        DbSet<Order> Order { get; set; }
        DbSet<OrderRequest> OrderRequest { get; set; }
        DbSet<Payment> Payment { get; set; }
        DbSet<Permission> Permission { get; set; }
        DbSet<PermissionGroup> PermissionGroup { get; set; }
        DbSet<Post> Post { get; set; }
        DbSet<PostCategory> PostCategory { get; set; }
        DbSet<PostComment> PostComment { get; set; }
        DbSet<PostTag> PostTag { get; set; }
        DbSet<Province> Province { get; set; }
        DbSet<Role> Role { get; set; }
        DbSet<RolePermission> RolePermission { get; set; }
        DbSet<SmsProviderConfiguration> SmsProviderConfiguration { get; set; }
        DbSet<SmsProviderNumber> SmsProviderNumber { get; set; }
        DbSet<SmsResponse> SmsResponse { get; set; }
        DbSet<SmsSetting> SmsSetting { get; set; }
        DbSet<SmsTemplate> SmsTemplate { get; set; }
        DbSet<Tag> Tag { get; set; }
        DbSet<Token> Token { get; set; }
        DbSet<Transaction> Transaction { get; set; }
        DbSet<User> User { get; set; }
        DbSet<UserPermission> UserPermission { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        int SaveChanges();
    }
}

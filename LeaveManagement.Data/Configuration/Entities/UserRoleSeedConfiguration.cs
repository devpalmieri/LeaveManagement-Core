using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeaveManagement.Web.Configuration.Entities
{
    public class UserRoleSeedConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                   new IdentityUserRole<string>
                   {
                       RoleId= "2a8c0565-6343-4447-8396-762c48md5861",
                       UserId= "1u9d0565-6343-5557-8396-762c48hf9811"
                   },
                   new IdentityUserRole<string>
                   {
                       RoleId = "3u8c0564-6343-4447-8396-762c48fh5889",
                       UserId = "5e8c0565-6343-4b57-8396-762c48bc5853"
                   }
                );
        }
    }
}
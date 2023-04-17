using LeaveManagement.Web.Constants;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeaveManagement.Web.Configuration.Entities
{
    public class RoleSeedConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole()
                {
                    Id= "2a8c0565-6343-4447-8396-762c48md5861",
                    Name=Roles.Administrator,
                    NormalizedName= Roles.Administrator.ToUpper()
                },
                new IdentityRole()
                {
                    Id = "3u8c0564-6343-4447-8396-762c48fh5889",
                    Name = Roles.User,
                    NormalizedName = Roles.User.ToUpper()
                }
             );
        }
    }
}
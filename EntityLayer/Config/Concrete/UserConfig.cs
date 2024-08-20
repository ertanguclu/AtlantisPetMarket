using EntityLayer.Config.Abstract;
using EntityLayer.Models.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Config.Concrete
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {

        public void Configure(EntityTypeBuilder<User> builder)
        {
            var hasher = new PasswordHasher<User>();
            builder.HasData(
                new User
                {
                    Id = 1, 
                    Name = "Ercan",
                    Surname = "Öztürk",
                    UserName = "ercanozturk",
                    NormalizedUserName = "ERCANOZTURK",
                    Email = "ercanozturk00@gmail.com",
                    NormalizedEmail = "ERCANOZTURK00@GMAIL.COM",
                    EmailConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    PasswordHash = hasher.HashPassword(null, "Ercan_123")

                }
                ) ;
          
        }
    }
}

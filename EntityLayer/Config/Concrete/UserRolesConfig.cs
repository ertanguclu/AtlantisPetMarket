using EntityLayer.Config.Abstract;
using EntityLayer.Models.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Config.Concrete
{
    public class UserRolesConfig : IEntityTypeConfiguration<IdentityUserRole<int>>
    {

        public void Configure(EntityTypeBuilder<IdentityUserRole<int>> builder)
        {

            builder.HasData(new IdentityUserRole<int>
            {
                UserId = 1,
                RoleId = 1
            });
        }
    }
}

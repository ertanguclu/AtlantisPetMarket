﻿using EntityLayer.Models.Concrete;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Abstract
{
    public interface ISocialMediaManager<TContext, T, TId> : IGenericManager<TContext, T, TId>
         where TContext : DbContext, new()
        where T : SocialMedia
    {
    }
}
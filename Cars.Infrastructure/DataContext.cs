using System;
using System.Collections.Generic;
using System.Text;

using Cars.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Cars.Infrastructure;

public class DataContext : IdentityDbContext<AppUser, IdentityRole, string>
{
    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
    }

    public DbSet<Car> Cars => Set<Car>();
}
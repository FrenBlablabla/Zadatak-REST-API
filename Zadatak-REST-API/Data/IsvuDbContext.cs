using System;
using Microsoft.EntityFrameworkCore;

public class IsvuDbContext : DbContext
{
    public IsvuDbContext(DbContextOptions<IsvuDbContext> options)
        : base(options)
    {
    }

    public DbSet<Student> Studenti { get; set; }
}
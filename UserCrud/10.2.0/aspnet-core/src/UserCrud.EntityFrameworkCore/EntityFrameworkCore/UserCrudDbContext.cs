using Abp.Zero.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UserCrud.Authorization.Roles;
using UserCrud.Authorization.Users;
using UserCrud.Countries;
using UserCrud.MultiTenancy;
using UserCrud.Students;

namespace UserCrud.EntityFrameworkCore;

public class UserCrudDbContext : AbpZeroDbContext<Tenant, Role, User, UserCrudDbContext>
{

    public UserCrudDbContext(DbContextOptions<UserCrudDbContext> options)
        : base(options)
    {
    }
    public DbSet<Student> Students { get; set; }

    public DbSet<UserCrud.Collage.Collage> Collages { get; set; }
    public DbSet<Country> Countries { get; set; }

}


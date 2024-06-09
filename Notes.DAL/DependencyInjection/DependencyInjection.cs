using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Notes.DAL.Repositories;
using Notes.Domain.Entities;
using Notes.Domain.Interfaces.Repositories;

namespace Notes.DAL.DependencyInjection
{
    public static class DependencyInjection
    {
        public static void AddDataAccessLayer(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("PostgreSQL");

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });

            services.InitRepositories();
        }

        public static void InitRepositories(this IServiceCollection services)
        {
            services.AddScoped<IBaseRepository<Note>, BaseRepository<Note>>();
            services.AddScoped<IBaseRepository<Reminder>, BaseRepository<Reminder>>();
            services.AddScoped<IBaseRepository<Tag>, BaseRepository<Tag>>();
        }
    }
}
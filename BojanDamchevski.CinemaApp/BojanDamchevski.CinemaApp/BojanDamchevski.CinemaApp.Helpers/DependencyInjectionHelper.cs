using BojanDamchevski.CinemaApp.DataAccess;
using BojanDamchevski.CinemaApp.DataAccess.Implementations;
using BojanDamchevski.CinemaApp.DataAccess.Interfaces;
using BojanDamchevski.CinemaApp.Domain.Models;
using BojanDamchevski.CinemaApp.Services.Implementations;
using BojanDamchevski.CinemaApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BojanDamchevski.CinemaApp.Helpers
{
    public class DependencyInjectionHelper
    {
        public static void InjectServices(IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IMovieService, MovieService>();
            services.AddTransient<ICinemaService, CinemaService>();
            //services.AddTransient<IReservationService, ReservationService>();

        }

        public static void InjectRepositories(IServiceCollection services)
        {
            services.AddTransient<IRepository<User>, UserRepository>();
            services.AddTransient<IRepository<Movie>, MovieRepository>();
            services.AddTransient<IRepository<Cinema>, CinemaRepository>();
            services.AddTransient<IRepository<Reservation>, ReservationRepository>();

        }

        public static void InjectDbContext(IServiceCollection services)
        {
            services.AddDbContext<CinemaAppDbContext>(options =>
                      options.UseSqlServer(@"Server=.\SQLExpress;Database=CinemaAppDb;Trusted_Connection=True")
            );
        }
    }
}

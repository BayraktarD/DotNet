using CatalogOnline_ClassLibrary.EntityModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Proiect___Catalog_Online.Interfaces.Repositories;
using Proiect___Catalog_Online.Interfaces.Services;
using Proiect___Catalog_Online.Repositories;
using Proiect___Catalog_Online.Services;

namespace Proiect___Catalog_Online.Configuration.DependencyInjection
{
    /// <summary>
    /// DI_Configuration
    /// </summary>
    public static class DI_Configuration
    {
        /// <summary>
        /// AddDependencies
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void AddDependencies(IServiceCollection services, IConfiguration configuration)
        {

            string connection = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"D:\\Proiecte\\GitHub\\DotNet\\Proiect - Catalog Online\\CatalogOnline-ClassLibrary\\Database\\SchoolDatabase.mdf\";Integrated Security=True";
           
            services.AddDbContext<SchoolDbContext>(options => options.UseSqlServer(connection, x => x.UseNetTopologySuite()));

            services.SERVICE_DI_Configuration(configuration);
            services.REPOSITORY_DI_Configuration(configuration);
        }

        /// <summary>
        /// SERVICE_DI_Configuration
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void SERVICE_DI_Configuration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<ISubjectService, SubjectService>();
            services.AddScoped<IMarkService, MarkService>();
            services.AddScoped<ITeacherService, TeacherService>();
        }

        /// <summary>
        /// REPOSITORY_DI_Configuration
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void REPOSITORY_DI_Configuration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<ISubjectRepository, SubjectRepository>();
            services.AddScoped<IMarkRepository, MarkRepository>();
            services.AddScoped<ITeacherRepository, TeacherRepository>();


        }
    }
}

﻿using Lab11Ex1.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace Lab11Ex1.Services
{
    public class DependencyInjection
    {
        public static void AddDependency(IServiceCollection services)
        {
            services.AddScoped<IStudentsServices, StudentsServices>();
            services.AddScoped<IAddressesServices,AddressesServices>();

            //services.AddMvc();
        }
    }
}

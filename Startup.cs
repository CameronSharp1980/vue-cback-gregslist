﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;
using vue_cback_gregslist.Repositories;

namespace vue_cback_gregslist
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        //Is readonly outside of the class. Writeable while class is not instantiated.
        private readonly string _connectionString = "";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _connectionString = configuration.GetSection("DB").GetValue<string>("mySQLConnectionString");
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddTransient<IDbConnection>(x => CreateDBContext());
            services.AddTransient<AutoRepository>();
            services.AddTransient<ProperyRepository>();
        }

        private IDbConnection CreateDBContext()
        {
            var connection = new MySqlConnection(_connectionString);
            connection.Open();
            return connection;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using GraphQL_API.Entities;
using Pomelo.EntityFrameworkCore.MySql;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Pomelo.EntityFrameworkCore.MySql.Design;
using GraphiQl;
using GraphQL.Server;
using GraphQL.Types;
using GraphQL;
using GraphQL.SystemTextJson;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;


namespace GraphQL_API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            
                

            
               // services.AddDbContext<cindy_okino_dbContext>(options =>
               // options.UseMySql(Configuration.GetConnectionString("MSQL")));

                services.AddDbContext<cindy_okino_warehouseContext>(options =>
                options.UseNpgsql(connectionString: Configuration.GetConnectionString("PSQL")));

               //  services.AddScoped<IDependencyResolver>(_ => new FuncDependencyResolver(_.GetRequiredService));
               // services.AddScoped<IDocumentExecuter, DocumentExecuter>();
               // services.AddScoped<IDocumentWriter, DocumentWriter>();
              // services.AddScoped<AuthorService>();
                //services.AddScoped<AuthorRepository>();
               // services.AddScoped<AuthorQuery>();
              //  services.AddScoped<AuthorType>();
               // services.AddScoped<BlogPostType>();
               // services.AddScoped<ISchema, GraphQLDemoSchema>();

               services.AddGraphQL();

                services.AddMvc(option => option.EnableEndpointRouting = false);

               
                

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public const string GraphQlPath = "/graphql";
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseGraphiQl(GraphQlPath);
            app.UseMvc();

            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

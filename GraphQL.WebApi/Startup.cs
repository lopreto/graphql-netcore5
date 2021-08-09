using GraphQL.Domain.IServices;
using GraphQL.Implementation;
using GraphQL.Infrastructure.DataAccess;
using GraphQL.Infrastructure.IRepositories;
using GraphQL.Infrastructure.Repositories;
using GraphQL.WebApi.GraphQLConfiguration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GraphQL.WebApi
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
            services.AddDbContext<GraphQLClientesContext>(options =>
              options.UseSqlServer(Configuration.GetConnectionString("ClientesDb")));

            services.AddInMemorySubscriptions();

            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IEmploymentService, EmploymentService>();

            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IEmploymentRepository, EmploymentRepository>();

            services
                .AddGraphQLServer()
                .AddQueryType<Query>()
                .AddMutationType<Mutation>()
                .AddSubscriptionType<Subscription>();

            services.AddCors(option =>
            {
                option.AddPolicy("allowedOrigin",
                    builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
                    );
            });

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseCors("allowedOrigin");

            app.UseWebSockets();
            app.UseRouting()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapGraphQL();
                });

            //app.UseAuthorization();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});
        }
    }
}

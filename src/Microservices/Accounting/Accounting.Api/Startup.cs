using DistributedBank.Domain.Core.Bus;
using DistributedBank.Infrastructure.EventBus;
using DistributedBank.Services.Accounting.Application.Interfaces;
using DistributedBank.Services.Accounting.Application.Services;
using DistributedBank.Services.Accounting.Domain.CommandHandlers;
using DistributedBank.Services.Accounting.Domain.Commands;
using DistributedBank.Services.Accounting.Domain.Interfaces;
using DistributedBank.Services.Accounting.Infrastructure.Context;
using DistributedBank.Services.Accounting.Infrastructure.Repository;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace DistributedBank.Services.Accounting.Api
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Domain Bus
            services.AddTransient<IEventBus, RabbitMQBus>();

            //Domain Commands
            services.AddTransient<IRequestHandler<CreateTransferCommand, bool>, TransferCommandHandler>();

            //Application Services
            services.AddTransient<IAccountRepository, AccountRepository>();            

            //Data
            services.AddTransient<IAccountService, AccountService>();

            services.AddDbContext<AccountingDbContext>(options =>
                options.UseSqlServer(_configuration.GetConnectionString("AccountingDbConnection")));

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Accounting Microservice", Version = "v1" });
            });

            services.AddMediatR(typeof(Startup));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Accounting Microservice v1"); });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

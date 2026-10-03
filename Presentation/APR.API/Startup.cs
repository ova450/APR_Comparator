using APRC.Core.Domain.Service.Repositories;
using APRC.Core.SharedKernel.Abstractions.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace APRC.Presentation.API;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    // Регистрация сервисов (DI-контейнер)
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        // 1. Настройка DbContext под SQL Server LocalDB
        // TODO: изменить на DomainContext?
        services.AddDbContext<AprDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

        // 2. Регистрация репозиториев (Scoped)
        // TODO: Проверить, нужно ли использовать конкретные реализации репозиториев или оставить только интерфейсы
        services.AddScoped(typeof(IRepository<>), typeof(IRepository<>));
        services.AddScoped<IBankRepository, BankRepository>();
        // Сюда же добавляются остальные специфичные репозитории по мере необходимости
    }

    // Настройка конвейера обработки HTTP-запросов (Middleware)
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}

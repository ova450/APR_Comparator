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
        services.AddDbContext<AprDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

        // 2. Регистрация репозиториев (Scoped)
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
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
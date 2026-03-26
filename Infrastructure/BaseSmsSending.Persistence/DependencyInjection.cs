namespace BaseSmsSending.Persistence;

using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using BaseSmsSending.Persistence.Settings;
using BaseSmsSending.Application.Common.ApplicationServices.Persistence;
using BaseSmsSending.Application.Common.ApplicationServices.BackgroundJob;
using BaseSmsSending.Persistence.Common;
using BaseSmsSending.Persistence.Repositories;
using BaseSmsSending.Persistence.DatabaseContext;
using BaseSmsSending.Persistence.BackgroundJobs.Outbox;


public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructurePersistence(this IServiceCollection services,
        IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString("DefaultConnection") ??
                                  throw new ArgumentNullException(nameof(configuration));


        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });

        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());

        services.AddSingleton<ISqlConnectionFactory>(_ =>
            new SqlConnectionFactory(connectionString));

        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        services.AddRepositories();

        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IProductRepository, ProductRepository>();

        return services;
    }

    private static IServiceCollection _AddOutbox(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<OutboxSettings>(configuration.GetSection("OutboxSettings"));
        return services;
    }

    /// <summary>
    /// Registers recurring job to process outbox messages.
    /// </summary>
    public static void AddOutBoxJob(this IServiceProvider serviceProvider, IConfiguration configuration)
    {
        using var scope = serviceProvider.CreateScope();

        var job = scope.ServiceProvider.GetRequiredService<IJobService>();
        var settings = scope.ServiceProvider
            .GetRequiredService<IOptions<OutboxSettings>>()
            .Value;

        job.Recurring<ProcessOutboxMessagesJob>(
            "ProcessOutboxMessages",
            job => job.Execute(),
            $"*/{settings.IntervalInMinutes} * * * *");
    }
}

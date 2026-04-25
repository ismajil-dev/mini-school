using FluentValidation;
using MediatR.Extensions.FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MiniSchool.Application.Dtos.Requests.Lessons;
using MiniSchool.Application.Repositories.Commands;
using MiniSchool.Application.Repositories.Queries;
using MiniSchool.Infrastructure.Data;
using MiniSchool.Infrastructure.Repositories.Commands;
using MiniSchool.Infrastructure.Repositories.Generals;
using MiniSchool.Infrastructure.Repositories.Queries;
using MiniSchool.Shared.Interfaces.Repositories;

namespace MiniSchool.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureAndPersistenceServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        // 1. DbContext Qeydiyyatı
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), sqlOptions =>
            {
                // Əgər Migration-lar başqa assembly-də (məsələn Persistence) qalacaqsa, bunu aktiv edin:
                // sqlOptions.MigrationsAssembly("MiniSchool.Persistence");
            });
        });

        services.AddScoped<DbContext>(provider => provider.GetRequiredService<AppDbContext>());

        //2.Command Repository - lərin Qeydiyyatı
        //QEYD: Əgər sinif adlarınız fərqlidirsə, uyğunlaşdırın.
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ILessonCommandRepository, LessonCommandRepository>();
        services.AddScoped<IStudentCommandRepository, StudentCommandRepository>();
        services.AddScoped<IExamCommandRepository, ExamCommandRepository>();

        // 3. Query Repository-lərin Qeydiyyatı
        services.AddScoped<ILessonQueryRepository, LessonQueryRepository>();
        services.AddScoped<IStudentQueryRepository, StudentQueryRepository>();
        services.AddScoped<IExamQueryRepository, ExamQueryRepository>();

        // Application layer-in assembly-sini tapırıq (Handler və Validator-lar ordadır)
        var applicationAssembly = typeof(LessonRegisterRequest).Assembly;

        // MediatR-i register edirik
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(applicationAssembly);
        });

        // FluentValidation-da olan bütün validator-ları register edirik
        services.AddValidatorsFromAssembly(applicationAssembly);

        // MediatR.Extensions.FluentValidation.AspNetCore paketi üçün Pipeline qeydiyyatı:
        // Bu kod request handler-ə çatmamışdan əvvəl validasiyanı avtomatik işə salır.
        services.AddFluentValidation(new[] { applicationAssembly });

        return services;
    }
}

using IS5.TutoriaFormat.WebApi.ApplicationLayer.Interface;
using IS5.TutoriaFormat.WebApi.ApplicationLayer.Main;
using IS5.TutoriaFormat.WebApi.DomainLayer.Core;
using IS5.TutoriaFormat.WebApi.DomainLayer.Interface;
using IS5.TutoriaFormat.WebApi.InfraestructureLayer.Interface;
using IS5.TutoriaFormat.WebApi.InfraestructureLayer.Repository;
using IS5.TutoriaFormat.WebApi.LayerInfraestructure.Data;

namespace IS5.TutoriaFormat.WebApi.Modules.Injection
{
    public static class InjectionExtension
    {
        public static IServiceCollection AddInjection(this IServiceCollection services)
        {
            services.AddSingleton<IConnectionDataBase, ConnectionDataBase>();

            //ProfessorDto
            services.AddScoped<IProfessorApplication, ProfessorAplication>();

            services.AddScoped<IActivityApplication, ActivityApplication>();

            services.AddScoped<IAssistanceApplication, AssistanceApplication>();

            services.AddScoped<IStudentApplication, StudentApplication>();

            services.AddScoped<IActivitiesFormatApplication, ActivitiesFormatApplication>();

            services.AddScoped<IFormatOneApplication, FormatOneApplication>();

            services.AddScoped<IFormatThreeApplication, FormatThreeApplication>();

            services.AddScoped<IFormatEvidencesApplication, FormatEvidencesApplication>();

            services.AddScoped<IIncidencesFormatApplication, IncidencesFormatApplication>();
            services.AddScoped<IFormatFiveApplicationcs, FormatFiveApplication>();

            services.AddScoped<IIncidenceApplication, IncidenceApplication>();
            services.AddScoped<IFormatFourApplication, FormatFourApplication>();

            services.AddScoped<IFormatRepository, FormatRepository>();
            services.AddScoped<IFormatDomain, FormatDomain>();
            services.AddScoped<IFormatApplication, FormatApplication>();

            services.AddScoped<IFormatTwoApplication, FormatTwoApplication>();

            //format
            //services.AddScoped<IMailMergeDataSource, Format01MailMergeDataSource>();



            return services;
        }
    }
}

using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Notes.Application.Mapping;
using Notes.Application.Mediators.Note.Commands;
using Notes.Application.Mediators.Note.Queries;
using Notes.Application.Mediators.Reminder.Queries;
using Notes.Application.Services;
using Notes.Application.Validations.Note;
using Notes.Application.Validations.Reminder;
using Notes.Application.Validations.Tag;
using Notes.Domain.DTO.Note;
using Notes.Domain.DTO.Reminder;
using Notes.Domain.DTO.Tag;
using Reminders.Application.Mediators.Reminder.Commands;
using Reminders.Application.Mediators.Reminder.Queries;

namespace Notes.Application.DependencyInjection
{
    public static class DependencyInjection
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(NoteMapping),
                                   typeof(ReminderMapping),
                                   typeof(TagMapping));

            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(CreateNoteCommand).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(UpdateNoteCommand).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(DeleteNoteCommand).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(SetNodeTagCommand).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(GetNotesQuery).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(GetNoteByIdQuery).Assembly);

                cfg.RegisterServicesFromAssembly(typeof(CreateReminderCommand).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(UpdateReminderCommand).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(DeleteReminderCommand).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(SetReminderTagCommand).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(GetRemindersQuery).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(GetReminderByIdQuery).Assembly);
            });

            services.InitServices();
        }

        private static void InitServices(this IServiceCollection services)
        {
            services.AddScoped<IValidator<CreateNoteDTO>, CreateNoteValidator>();
            services.AddScoped<IValidator<UpdateNoteDTO>, UpdateNoteValidator>();

            services.AddScoped<IValidator<CreateReminderDTO>, CreateReminderValidator>();
            services.AddScoped<IValidator<UpdateReminderDTO>, UpdateReminderValidator>();

            services.AddScoped<IValidator<CreateTagDTO>, CreateTagValidator>();
            services.AddScoped<IValidator<UpdateTagDTO>, UpdateTagValidator>();

            services.AddScoped<INoteService, NoteService>();
            services.AddScoped<IReminderService, ReminderService>();
            services.AddScoped<ITagService, TagService>();
        }
    }
}
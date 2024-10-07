using FluentValidation;
using WebApplication5.Commands.CRUD.Create;
using WebApplication5.Commands.CRUD.Delete;
using WebApplication5.Commands.CRUD.Update;
using WebApplication5.Interfaces;
using WebApplication5.Queries.GetEntity;

namespace WebApplication5.DAL
{
    public class Reminder : IEntity
    {
        public int Id { get; set; }

        public string Header { get; set; } = string.Empty;

        public string Text { get; set; } = string.Empty;

        public DateTime ReminderTime { get; set; } = DateTime.Now;

    }

    public class CreateValidatorReminder<TEntity> : AbstractValidator<CreateCommand<TEntity>>
    where TEntity : Reminder
    {
        public CreateValidatorReminder()
        {
            RuleFor(cmd => cmd.Entity.Header)
                .NotEmpty().WithMessage("Header is required.");
            RuleFor(cmd => cmd.Entity.Text)
                .NotEmpty().WithMessage("Text is required.");
            RuleFor(cmd => cmd.Entity.ReminderTime)
                .NotEmpty().WithMessage("ReminderTime is required.")
                .Must(reminderTime => reminderTime <= DateTime.Now.AddYears(5)).WithMessage("ReminderTime must be within the next 5 years.")
                .Must(reminderTime => reminderTime.Minute == 0 && reminderTime.Second == 0 && reminderTime.Millisecond == 0).WithMessage("ReminderTime must be an exact hour (e.g., 1:00, 2:00).");
        }
    }

    public class DeleteValidatorReminder<TEntity> : AbstractValidator<DeleteCommand<TEntity>>
where TEntity : Reminder
    {
        public DeleteValidatorReminder()
        {
            RuleFor(cmd => cmd.Entity.Id).NotEmpty().WithMessage("Id is required.")
                .GreaterThan(0).WithMessage("Id must be greater than 0.");
        }
    }

    public class UpdateValidatorReminder<TEntity> : AbstractValidator<UpdateCommand<TEntity>>
    where TEntity : Reminder
    {
        public UpdateValidatorReminder()
        {
            RuleFor(cmd => cmd.Entity.Id)
                .NotEmpty().WithMessage("Id is required.");
            RuleFor(cmd => cmd.Entity.Header)
                .NotEmpty().WithMessage("Header is required.");
            RuleFor(cmd => cmd.Entity.Text)
                .NotEmpty().WithMessage("Text is required.");
            RuleFor(cmd => cmd.Entity.ReminderTime)
                .NotEmpty().WithMessage("ReminderTime is required.")
                .Must(reminderTime => reminderTime <= DateTime.Now.AddYears(5)).WithMessage("ReminderTime must be within the next 5 years.")
                .Must(reminderTime => reminderTime.Minute == 0 && reminderTime.Second == 0 && reminderTime.Millisecond == 0).WithMessage("ReminderTime must be an exact hour (e.g., 1:00, 2:00).");
        }
    }

    public class GetByIdValidatorReminder<TEntity> : AbstractValidator<GetQuery<TEntity>>
        where TEntity : Reminder
    {
        public GetByIdValidatorReminder()
        {
            RuleFor(query => query.Entity.Id).NotEmpty().WithMessage("Id is required.")
                .GreaterThan(0).WithMessage("Id must be greater than 0.");
        }
    }
}

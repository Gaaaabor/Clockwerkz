using Clockwerkz.Application.Jobs.Commands;
using FluentValidation;

namespace Clockwerkz.Application.Jobs.Validators
{
    public class ScheduleJobValidator : AbstractValidator<ScheduleJobCommand>
    {
        public ScheduleJobValidator()
        {
            RuleFor(x => x.JobName)
                    .MaximumLength(100).WithMessage("JobName has max. length of 100 characters")
                    .NotEmpty().WithMessage("JobName is required.");

            RuleFor(x => x.GroupName)
                .MaximumLength(100).WithMessage("GroupName has max. length of 100 characters")
                .NotEmpty().WithMessage("GroupName is required.");

            RuleFor(x => x.CronExpression)
                .Matches(@"^((\*|\?|\d+((\/|\-){0,1}(\d+))*)\s*){7}$")
                .WithMessage("CronExpression must be in a format like: 0 */5 * ? * *");
        }
    }
}

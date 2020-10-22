using FluentValidation;

namespace aspnetcore_cqrs.Mediator.Home.Queries.GetPingQuery
{
    public class GetPingQueryValidator : AbstractValidator<GetPingQuery>
    {
        public GetPingQueryValidator()
        {
            RuleFor(c => c.Command)
            .NotEmpty()
            .WithMessage("Command is empty.");
        }
    }
}
using FluentValidation;

namespace aspnetcore_cqrs.Mediator.People.Commands.CreatePersonCommand
{
    public class CreatePersonCommandValidator : AbstractValidator<CreatePersonCommand>
    {
        public CreatePersonCommandValidator()
        {
            RuleFor(c => c.Initial)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("คำนำหน้าว่างเปล่า")
                .Must(CheckInitial)
                .WithMessage("คำนำหน้าไม่ถูกต้อง");
        }

        private bool CheckInitial(string initial)
        {
            switch (initial)
            {
                case "นาย":
                case "นางสาว":
                case "นาง":
                    return true;
                default:
                    return false;
            }
        }
    }
}
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using aspnetcore_cqrs.Data;
using MediatR;

namespace aspnetcore_cqrs.Mediator.People.Commands.CreatePersonCommand
{
    public class CreatePersonCommand : IRequest<Unit>
    {
        [Display(Name = "คำนำหน้า")]
        public string Initial { get; set; }

        [Display(Name = "ชื่อ")]
        public string FirstName { get; set; }

        [Display(Name = "นามสกุล")]
        public string LastName { get; set; }

        [Display(Name = "วันเกิด")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand, Unit>
        {
            private readonly ApplicationDbContext _context;
            public CreatePersonCommandHandler(ApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
            {
                var newPerson = new aspnetcore_cqrs.Data.Person()
                {
                    Initial = request.Initial,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    BirthDate = request.BirthDate
                };
                await _context.People.AddAsync(newPerson);
                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
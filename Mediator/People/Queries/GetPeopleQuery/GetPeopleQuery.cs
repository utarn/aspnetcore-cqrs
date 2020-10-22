using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using aspnetcore_cqrs.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace aspnetcore_cqrs.Mediator.People.Queries.GetPeopleQuery
{
    public class GetPeopleQuery : IRequest<IEnumerable<PeopleViewModel>>
    {
        public class GetPeopleQueryHandler : IRequestHandler<GetPeopleQuery, IEnumerable<PeopleViewModel>>
        {
            private readonly ApplicationDbContext _context;
            public GetPeopleQueryHandler(ApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<PeopleViewModel>> Handle(GetPeopleQuery request, CancellationToken cancellationToken)
            {
                return await _context.People.Select(p => new PeopleViewModel()
                {
                    PersonId = p.PersonId,
                    FullName = $"{p.Initial}{p.FirstName} {p.LastName}",
                    Age = (DateTime.Now.Year - p.BirthDate.Year) -
                       (DateTime.Now.DayOfYear < p.BirthDate.DayOfYear ? 1 : 0)
                }).ToListAsync();
            }
        }
    }
}
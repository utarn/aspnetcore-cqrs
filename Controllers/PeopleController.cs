using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aspnetcore_cqrs.Data;
using aspnetcore_cqrs.Mediator.People.Commands.CreatePersonCommand;
using aspnetcore_cqrs.Mediator.People.Queries.GetPeopleQuery;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace aspnetcore_cqrs.Controllers
{
    public class PeopleController : MvcController
    {
        public PeopleController() { }

        public async Task<IActionResult> Index()
        {
            var model = await Mediator.Send(new GetPeopleQuery());
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreatePersonCommand command)
        {
            if (ModelState.IsValid)
            {
                await Mediator.Send(command);
                return RedirectToAction("Index");
            }
            return View(command);
        }

    }
}
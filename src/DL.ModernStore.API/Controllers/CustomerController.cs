using DL.ModernStore.Domain.Commands.Handlers;
using DL.ModernStore.Domain.Commands.Inputs;
using DL.ModernStore.Domain.Repositories;
using DL.ModernStore.Infra.Transactions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DL.ModernStore.API.Controllers
{
    //[Route("api")]
    public class CustomerController : BaseController
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly CustomerCommandHandler _handler;

        public CustomerController(ICustomerRepository customerRepository, IUow uow, CustomerCommandHandler handler)
            : base(uow)
        {
            _customerRepository = customerRepository;
            _handler = handler;
        }

        [HttpPost]
        [Route("v1/customer/insert")]
        public async Task<IActionResult> Post([FromBody]RegisterCustomerCommand command)
        {
            var result = _handler.Handle(command);
            return await Response(result, _handler.Notifications);
        }

        [HttpPost]
        [Route("v1/products/update/{id}")]
        public IActionResult Put(Guid id)
        {
            return Ok("inserindo um produto!");
        }

        [HttpPost]
        [Route("v1/products/delete/{id}")]
        public IActionResult Delete(Guid id)
        {
            return Ok("inserindo um produto!");
        }
    }
}

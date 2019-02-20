using DL.ModernStore.Infra.Transactions;
using FluentValidator;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DL.ModernStore.API.Controllers
{
    public class BaseController : Controller
    {
        private readonly IUow _uow;

        public BaseController(IUow uow)
        {
            _uow = uow;
        }

        public async Task<IActionResult> Response(object result, IEnumerable<Notification> notifications)
        {
            if(!notifications.Any())
            {
                try
                {
                    _uow.Commit();
                    return Ok(new {
                        success = true,
                        data = result
                    });

                }
                catch
                {
                    // HELMAH - ver isso
                    return BadRequest(new
                    {
                        success = false,
                        data = new[] { "Ocorreu um erro no servidor" }
                    });
                }
            }
            else
            {
                return BadRequest(new
                {
                    success = false,
                    data = notifications
                });
            }
             
            
        }
    }
}

using DynamicForm.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace DynamicForm.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DynamicFormController : ControllerBase
    {

        public DynamicFormController()
        {

        }

        [HttpPost]
        public async Task<IActionResult> CreateForm([FromBody] CreateApplication form)
        {
            return Ok();
        }
    }
}
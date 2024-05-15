using DynamicForm.Application.DTOs;
using DynamicForm.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace DynamicForm.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DynamicFormController : ControllerBase
    {
        private readonly IApplicationFormService applicationService;

        public DynamicFormController(IApplicationFormService applicationService)
        {
            this.applicationService = applicationService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateForm([FromBody] CreateApplicationForm form)
        {
            var newApplicationResult = applicationService.CreateNewForm(form);

            if (newApplicationResult.HasError)
                return BadRequest(newApplicationResult.Error);

            var newApplication = newApplicationResult.Value;

            return Ok(newApplication);
        }
    }
}
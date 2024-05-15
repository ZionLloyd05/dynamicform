using DynamicForm.Application.DTOs;
using DynamicForm.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace DynamicForm.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DynamicFormsController : ControllerBase
    {
        private readonly IApplicationFormService applicationService;

        public DynamicFormsController(IApplicationFormService applicationService)
        {
            this.applicationService = applicationService;
        }

        [HttpPost]
        public IActionResult CreateApplicationForm([FromBody] CreateApplicationForm form)
        {
            var newApplicationResult = applicationService.CreateNewForm(form);

            if (newApplicationResult.HasError)
                return BadRequest(newApplicationResult.Error);

            var newApplication = newApplicationResult.Value;

            return Ok(newApplication);
        }

        [HttpGet]
        public async Task<IActionResult> GetApplicationForms()
        {
            var applicationFormResult = await applicationService.GetApplications();

            if (applicationFormResult.HasError)
                return BadRequest(applicationFormResult.Error);

            var applicationForms = applicationFormResult.Value;

            return Ok(applicationForms);
        }

        [HttpPut]
        [Route("{applicationId}/questions/{questionId}")]
        public async Task<IActionResult> UpdateApplicationQuestion(
            string applicationId, string questionId, [FromBody] UpdateQuestion question)
        {
            var applicationFormResult = await applicationService.UpdateQuestionInApplication(
                applicationId,
                questionId,
                question);

            if (applicationFormResult.HasError)
                return BadRequest(applicationFormResult.Error);

            var applicationForms = applicationFormResult.Value;

            return Ok(applicationForms);
        }

        [HttpPost]
        [Route("{applicationId}/submit")]
        public async Task<IActionResult> SubmitApplication(
            string applicationId, [FromBody]CreateApplicationSubmission submission)
        {
            var submissionResult = await applicationService.SaveSubmission(
                applicationId, 
                submission);

            if (submissionResult.HasError)
                return BadRequest(submissionResult.Error);

            return Ok();
        }
    }
}
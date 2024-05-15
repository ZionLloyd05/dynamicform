using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicForm.Application.DTOs;
using DynamicForm.Bases;
using Xunit;

namespace DynamicForm.Tests.Services.ApplicationForm;

public partial class ApplicationFormServiceTests
{
    [Fact]
    public void ShouldReturnValidationError_OnCreatingNewApplication()
    {
        // given
        CreateApplicationForm invalidApplicationForm = CreateApplicationWithEmptyTitle();

        var expectedErrorResponse = new Error(
            "title cannot be empty",
            "Invalid.Form",
            false);

        // when
        Result<CreatedApplicationForm> createApplicationFormResult = 
            this.applicationFormService.CreateNewApplication(invalidApplicationForm);

        // then
        Assert.True(createApplicationFormResult.HasError);

        var error = createApplicationFormResult.Error;

        Assert.Equal(expectedErrorResponse.ErrorCode, error.ErrorCode);
    }
}

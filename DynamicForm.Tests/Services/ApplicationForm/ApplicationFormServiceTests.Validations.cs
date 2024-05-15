using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicForm.Application.Const;
using DynamicForm.Application.DTOs;
using DynamicForm.Bases;
using Xunit;

namespace DynamicForm.Tests.Services.ApplicationForm;

public partial class ApplicationFormServiceTests
{
    [Fact]
    public void ShouldReturnValidationError_OnCreatingNewApplication_WithEmptyTitle()
    {
        // given
        CreateApplicationForm invalidApplicationForm = CreateApplicationWithEmptyTitle();

        var expectedErrorResponse = new Error(
            Messages.TITLE_ERROR,
            ErrorCodes.INVALID_FORM,
            false);

        // when
        Result<CreatedApplicationForm> createApplicationFormResult = 
            this.applicationFormService.CreateNewApplication(invalidApplicationForm);

        // then
        Assert.True(createApplicationFormResult.HasError);

        var error = createApplicationFormResult.Error;

        Assert.Equal(expectedErrorResponse.ErrorCode, error.ErrorCode);
    }

    [Fact]
    public void ShouldReturnValidationError_OnCreatingNewApplication_WithEmptyDescription()
    {
        // given
        CreateApplicationForm invalidApplicationForm = CreateApplicationWithEmptyDescription();

        var expectedErrorResponse = new Error(
            Messages.DESCRIPTION_ERROR,
            ErrorCodes.INVALID_FORM,
            false);

        // when
        Result<CreatedApplicationForm> createApplicationFormResult =
            this.applicationFormService.CreateNewApplication(invalidApplicationForm);

        // then
        Assert.True(createApplicationFormResult.HasError);

        var error = createApplicationFormResult.Error;

        Assert.Equal(expectedErrorResponse.ErrorCode, error.ErrorCode);
    }

    [Fact]
    public void ShouldReturnValidationError_OnCreatingNewApplication_WithEmptyQuestionLabel()
    {
        // given
        CreateApplicationForm invalidApplicationForm = CreateApplicationWithEmptyQuestionLabel();

        var expectedErrorResponse = new Error(
            Messages.QUESTIONLABEL_ERROR,
            ErrorCodes.INVALID_FORM,
            false);

        // when
        Result<CreatedApplicationForm> createApplicationFormResult =
            this.applicationFormService.CreateNewApplication(invalidApplicationForm);

        // then
        Assert.True(createApplicationFormResult.HasError);

        var error = createApplicationFormResult.Error;

        Assert.Equal(expectedErrorResponse.ErrorCode, error.ErrorCode);
    }

    [Fact]
    public void ShouldReturnValidationError_OnCreatingNewApplicationWithDropdownType_WithEmptyQuestionMetadata()
    {
        // given
        CreateApplicationForm invalidApplicationForm = CreateApplicationWithEmptyMetadataLabel();

        var expectedErrorResponse = new Error(
            Messages.QUESTIONTYPE_ERROR,
            ErrorCodes.INVALID_FORM,
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

using DynamicForm.Application.DTOs;
using DynamicForm.Application.Implementations.Builders;
using DynamicForm.Application.Implementations.Services;
using DynamicForm.Application.Interfaces.Builders;
using DynamicForm.Application.Interfaces.Data;
using DynamicForm.Application.Interfaces.Services;
using DynamicForm.Domain.Enums;
using Moq;

namespace DynamicForm.Tests.Services.ApplicationForm;

public partial class ApplicationFormServiceTests
{
    private readonly IApplicationFormBuilder applicationBuilder;
    private readonly IQuestionBuilder questionBuilder;
    private readonly Mock<IRepository> repositoryMock;
    private readonly IApplicationFormService applicationFormService;

    public ApplicationFormServiceTests()
    {
        this.applicationBuilder = new ApplicationFormBuilder();
        this.questionBuilder = new QuestionBuilder();
        this.repositoryMock = new Mock<IRepository>();

        this.applicationFormService = new ApplicationFormService(
            applicationBuilder: this.applicationBuilder,
            questionBuilder: this.questionBuilder,
            repository: this.repositoryMock.Object);
    }

    public CreateApplicationForm CreateApplicationWithEmptyTitle()
    {
        var applicationForm = new CreateApplicationForm()
        {
            Title = string.Empty,
            Description = "Hello Description",
            Questions = new List<CreateQuestion>(),
        };

        return applicationForm;
    }

    public CreateApplicationForm CreateApplicationWithEmptyDescription()
    {
        var applicationForm = new CreateApplicationForm()
        {
            Title = "Hello",
            Description = string.Empty,
            Questions = new List<CreateQuestion>(),
        };

        return applicationForm;
    }

    public CreateApplicationForm CreateApplicationWithEmptyQuestionLabel()
    {
        var applicationForm = new CreateApplicationForm()
        {
            Title = "Hello",
            Description = "description for hello",
            Questions = new List<CreateQuestion>()
            {
                new CreateQuestion()
                {
                    Label = string.Empty,
                    Placeholder = "hello",
                    QuestionCategory = QuestionCategory.PersonalInformation,
                    QuestionType = QuestionType.Text,
                    QuestionMetaData = new List<CreateQuestionMetaData>(),
                    Validator = new CreateQuestionValidator()
                }
            },
        };

        return applicationForm;
    }
}

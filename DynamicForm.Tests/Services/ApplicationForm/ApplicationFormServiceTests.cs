using DynamicForm.Application.Implementations.Services;
using DynamicForm.Application.Interfaces.Builders;
using DynamicForm.Application.Interfaces.Data;
using DynamicForm.Application.Interfaces.Services;
using Moq;

namespace DynamicForm.Tests.Services.ApplicationForm;

public partial class ApplicationFormServiceTests
{
    private readonly Mock<IApplicationFormBuilder> applicationBuilderMock;
    private readonly Mock<IQuestionBuilder> questionBuilderMock;
    private readonly Mock<IRepository> repositoryMock;
    private readonly IApplicationFormService applicationFormService;

    public ApplicationFormServiceTests()
    {
        this.applicationBuilderMock = new Mock<IApplicationFormBuilder>();
        this.questionBuilderMock = new Mock<IQuestionBuilder>();
        this.repositoryMock = new Mock<IRepository>();

        this.applicationFormService = new ApplicationFormService(
            applicationBuilder: this.applicationBuilderMock.Object,
            questionBuilder: this.questionBuilderMock.Object,
            repository: this.repositoryMock.Object);
    }
}

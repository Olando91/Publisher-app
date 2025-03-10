using Applikation.Porte.Udgående;
using Autofac.Extras.Moq;
using FluentAssertions;
using Moq;
using System.Threading.Tasks;
using Tests.Utilities.Requests;
using System.Net;
using Applikation.UseCases.Create;

namespace Tests;

public class AddAuthorUseCaseTest
{
    [Fact]
    public async Task AddAuthor_must_return_HttpStatusCode200_when_author_is_added_successfully()
    {
        // Arrange
        var mock = AutoMock.GetLoose();
        var myUseCase = mock.Create<AddAuthorUseCase>();

        var request = CreateRequest.AddAuthorRequest();

        var authorRepositoryMock = mock.Mock<IAuthorRepository>();
        //authorRepositoryMock
        //    .Setup(x => x.GetAuthorByIdAsync(AUTHORID.CREATE(ID)))
        //    .ReturnsAsync(AUTHOR);

        // Act
        var apiResponse = await myUseCase.ExecuteAsync(request);

        // Assert
        apiResponse.Data.Should().NotBeNull();
        apiResponse.StatusCode.Should().Be(HttpStatusCode.OK);
        apiResponse.Error.Should().BeNull();

        authorRepositoryMock.Verify(x => x.SaveChangesAsync(), Times.Once);
    }
}